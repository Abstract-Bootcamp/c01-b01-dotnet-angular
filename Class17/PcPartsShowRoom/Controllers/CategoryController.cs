using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using PcPartsShowRoom.DataAccess;
using PcPartsShowRoom.Models;
using Microsoft.EntityFrameworkCore;
using PcPartsShowRoom.ViewModels;
using PcPartsShowRoom.ViewModels.Category;
using System.Linq;

namespace PcPartsShowRoom.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : ControllerBase
{
    private readonly PartsContext _context;
    public CategoryController(PartsContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryVM>> Get()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories.Select(p => new CategoryVM
        {
            Id = p.Id,
            Name = p.Name
        }).ToList();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryVM vm)
    {
        var category = new Category
        {
            Name = vm.Name
        };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
