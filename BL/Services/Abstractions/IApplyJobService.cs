using BL.DTOs.ApplyJobDTOs;
using CORE.Models;
namespace BL.Services.Abstractions
{
    public interface IApplyJobService
    {
        Task<ICollection<GetApplyJobDTO>> GetApplicationsByJobIdAsync(int jobId);
        Task DeleteApplicationsByJobIdAsync(int jobId);
        Task SendEmailAsync(ApplyJob applyJob, string cvFilename);
    }
}
