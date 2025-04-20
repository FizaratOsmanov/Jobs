using CORE.Models;

namespace DATA.Repositories.Abstractions
{
    public interface IJobRepository:IRepository<Job>
    {

        Task<ICollection<Job>> GetJobsByCategoryAsync(int categoryId);
    }
}
