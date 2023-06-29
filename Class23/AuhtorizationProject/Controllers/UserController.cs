using System.Net;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using AuhtorizationProject.Models;
using AuhtorizationProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AuhtorizationProject.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    public readonly ApplicationDbContext _context;
    public readonly UserManager<User> _userManager;
    public readonly SignInManager<User> _signInManager;
    public UserController(ApplicationDbContext context,
    UserManager<User> userManager,
    SignInManager<User> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<List<User>> Get()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet]
    public async Task<User> GetById(string id)
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
                var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, model.Password);
                if (isPasswordCorrect)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        ModelState.AddModelError("Login", "Invalid login attempt.");
                    }
                }
            }
            // validate password
            // sign in
        }
        return BadRequest(ModelState);
    }

}
