using Microsoft.EntityFrameworkCore;
using PcPartsManager.Models;

namespace PcPartsManager.Repositories;

public interface IRepository<T> where T : IEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationContext context)
    {
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}