using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PcPartsManager.Models;
using PcPartsManager.ViewModels;

namespace PcPartsManager.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Pagination<CategoryVM>> GetPagination(int pageIndex, int pageSize);
    }

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pagination<CategoryVM>> GetPagination(int pageIndex, int pageSize)
        {
            var query = _context.Categories;
            var length = query.Count();

            var categories = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

            var result = categories.Select(p => new CategoryVM
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new Pagination<CategoryVM>
            {
                Length = length,
                Data = result
            };
        }
    }
}
