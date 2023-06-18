using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using PcPartsShowRoom.DataAccess;
using PcPartsShowRoom.Models;
using Microsoft.EntityFrameworkCore;
using PcPartsShowRoom.ViewModels;
using PcPartsShowRoom.ViewModels.Parts;
using System.Linq;

namespace PcPartsShowRoom.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PartsController : ControllerBase
{
    private readonly PartsContext _context;
    public PartsController(PartsContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<PartVM>> GetPartsByCategory(int categoryId)
    {
        var parts = await _context.Parts
        .Include(p => p.SubCategory)
        .Where(p => p.SubCategory.CategoryId == categoryId)
        .ToListAsync();

        return parts.Select(p => new PartVM
        {
            Id = p.Id,
            Name = p.Name,
            SubCategory = new SubCategoryVM
            {
                Id = p.SubCategory.Id,
                Name = p.SubCategory.Name
            }
        }).ToList();
    }

    [HttpGet]
    public async Task<IEnumerable<PartVM>> GetPartsBySubCategory(int subCategoryId)
    {
        var parts = await _context.Parts
        .Include(p => p.SubCategory)
        .Where(p => p.SubCategoryId == subCategoryId)
        .ToListAsync();


        return parts.Select(p => new PartVM
        {
            Id = p.Id,
            Name = p.Name,
            SubCategory = new SubCategoryVM
            {
                Id = p.SubCategory.Id,
                Name = p.SubCategory.Name
            }
        }).ToList();
    }

    [HttpGet]
    public async Task<IEnumerable<PartVM>> Get()
    {
        var parts = await _context.Parts
        .Include(p => p.SubCategory)
        .ToListAsync();

        return parts.Select(p => new PartVM
        {
            Id = p.Id,
            Name = p.Name,
            SubCategory = new SubCategoryVM
            {
                Id = p.SubCategory.Id,
                Name = p.SubCategory.Name
            }
        }).ToList();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePartVM vm)
    {
        var part = new Part
        {
            Name = vm.Name,
            SubCategoryId = vm.SubCategoryId
        };
        _context.Parts.Add(part);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
