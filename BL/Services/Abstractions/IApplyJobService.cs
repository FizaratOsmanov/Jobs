using BL.DTOs.ApplyJobDTOs;
using CORE.Models;

namespace BL.Services.Abstractions
{
    public interface IApplyJobService
    {
        Task SendEmailAsync(ApplyJob applyJob, string cvFilename);
    }
}
