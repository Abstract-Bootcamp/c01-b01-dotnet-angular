using System;
using System.Net;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using AuhtorizationProject.Models;
using AuhtorizationProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace AuhtorizationProject.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    public readonly ApplicationDbContext _context;
    public readonly UserManager<User> _userManager;
    public readonly SignInManager<User> _signInManager;
    public readonly IConfiguration _config;
    public UserController(
        ApplicationDbContext context,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IConfiguration config)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
    }


    [HttpGet]
    [Authorize(Policy = IdentityData.AdminPolicyName)]
    public async Task<List<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }


    [HttpGet]
    [Authorize(Policy = IdentityData.UserPolicyName)]
    public async Task<List<User>> GetByUsername()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<List<User>> Get()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet]
    public async Task<User> GetById(string id)// should be user claim
    {
        return await _context.Users.SingleAsync(u => u.Id == id);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // create user model
            var user = new User { UserName = model.Username, Email = model.Email };
            // register user
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var claims = new List<Claim>();
                if (model.IsAdmin)
                {
                    // add admin claim
                    claims.Add(new Claim(IdentityData.AdminClaimName, IdentityData.AdminClaimName));
                }
                else
                {
                    // add user claim
                    claims.Add(new Claim(IdentityData.UserClaimName, IdentityData.UserClaimName));
                }

                await _userManager.AddClaimsAsync(user, claims);

                return Ok();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }

        return BadRequest(ModelState);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // get user
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user is not null)
            {

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("Login", "Invalid login attempt.");
                    return BadRequest(ModelState);
                }

                var claims = await _userManager.GetClaimsAsync(user);
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]!));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["JwtSettings:Issuer"],
                    audience: _config["JwtSettings:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: signingCredentials);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
        }
        return BadRequest(ModelState);
    }
}
