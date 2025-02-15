using CORE.Models;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
namespace DATA.Repositories.Implementations
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(AppDbContext context) : base(context)
        {
        }
    }
}
