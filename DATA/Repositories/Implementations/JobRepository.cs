using CORE.Models;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
namespace DATA.Repositories.Implementations
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        readonly AppDbContext _appDbContext;
        public JobRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<ICollection<Job>> GetJobsByCategoryAsync(int categoryId)
        {
            return await _appDbContext.Jobs
                .Where(j => j.CategoryId == categoryId && !j.IsDeleted)
                .ToListAsync();
        }
    }
}
