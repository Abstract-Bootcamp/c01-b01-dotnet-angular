using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using PcPartsShowRoom.DataAccess;
using PcPartsShowRoom.Models;
using Microsoft.EntityFrameworkCore;
using PcPartsShowRoom.ViewModels;
using PcPartsShowRoom.ViewModels.SubCategory;
using System.Linq;

namespace PcPartsShowRoom.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SubCategoryController : ControllerBase
{
    private readonly PartsContext _context;
    public SubCategoryController(PartsContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<SubCategoryVM>> Get()
    {
        var subCategories = await _context.SubCategories.Include(sc => sc.Category).ToListAsync();

        return subCategories.Select(sc => new SubCategoryVM
        {
            Id = sc.Id,
            Name = sc.Name,
            Category = new CategoryVM
            {
                Id = sc.Category.Id,
                Name = sc.Category.Name
            }
        }).ToList();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSubCategoryVM vm)
    {
        var subCategory = new SubCategory
        {
            Name = vm.Name,
            CategoryId = vm.CategoryId
        };
        _context.SubCategories.Add(subCategory);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
