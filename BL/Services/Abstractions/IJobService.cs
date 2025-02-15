using BL.DTOs.JobDTOs;
using CORE.Models;
namespace BL.Services.Abstractions
{
    public interface IJobService
    {
        Task<ICollection<JobDetailDTO>> GetJobForDetailViewAsync();
        Task<ICollection<JobListDTO>> GetJobForListViewAsync();
        Task<ICollection<AdminGetJobDTO>> GetJobAdminItemsAsync();
        Task<Job> GetJobByIdAsync(int id);
        Task<UpdateJobDTO> GetJobByIdForUpdateAsync(int id);
        Task CreateJobAsync(CreateJobDTO dto);
        Task UpdateJobAsync(UpdateJobDTO dto);  
        Task SoftDeleteJobAsync(int id);
        Task HardDeleteJobAsync(int id);
    }
}
