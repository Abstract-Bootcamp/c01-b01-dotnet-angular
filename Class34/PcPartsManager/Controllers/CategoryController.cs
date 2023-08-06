using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using PcPartsManager.Models;
using Microsoft.EntityFrameworkCore;
using PcPartsManager.ViewModels;
using PcPartsManager.ViewModels.Category;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PcPartsManager.Repositories;

namespace PcPartsManager.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _uow;
    public CategoryController(ICategoryRepository repository, IUnitOfWork uow)
    {
        _uow = uow;
        _repository = repository;
    }

    [HttpGet]
    [Authorize(Policy = IdentityData.ViewCategoryPolicy)]
    public async Task<IEnumerable<CategoryVM>> Get()
    {

        var categories = await _repository.GetAllAsync();
        return categories.Select(p => new CategoryVM
        {
            Id = p.Id,
            Name = p.Name
        }).ToList();
    }


    [HttpGet]
    public async Task<Pagination<CategoryVM>> GetPagination(int pageIndex, int pageSize)// query string
    {
        return await _repository.GetPagination(pageIndex, pageSize);
    }


    [HttpGet("{id}")]
    public async Task<CategoryVM> Get(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        return new CategoryVM
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryVM vm)
    {
        var category = new Category
        {
            Name = vm.Name
        };
        await _repository.AddAsync(category);
        await _uow.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        _repository.Delete(category);
        await _uow.SaveChangesAsync();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id, CreateCategoryVM vm)
    {
        var category = await _repository.GetByIdAsync(id);
        category.Name = vm.Name;
        _repository.Update(category);
        await _uow.SaveChangesAsync();
        return Ok();
    }
}
