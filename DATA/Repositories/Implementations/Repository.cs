using CORE.Models.Base;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DATA.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<ICollection<T>> GetAllAsync(params string[] includes)
    {
        IQueryable<T> query = Table;

        if (includes.Length > 0)
        { 
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id, params string[] includes)
    {
        IQueryable<T> query = Table;

        if (includes.Length > 0)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.SingleOrDefaultAsync(e => e.Id == id);
    }
    public async Task CreateAsync(T entity)
    {
        entity.CreatedDate = DateTime.UtcNow.AddHours(4);
        await Table.AddAsync(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedDate = DateTime.UtcNow.AddHours(4);
        Table.Update(entity);
    }

    public void SoftDelete(T entity)
    {
        entity.DeletedDate = DateTime.UtcNow.AddHours(4);
        entity.IsDeleted = true;
        _context.Update(entity);
    }

    public void HardDelete(T entity)
    {
         Table.Remove(entity);
    }
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
