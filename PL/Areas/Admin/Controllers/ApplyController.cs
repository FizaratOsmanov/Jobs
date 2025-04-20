using BL.DTOs.ApplyJobDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using DATA.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ApplyController : Controller
    {
        readonly IApplyJobService _applyJobService;
        readonly AppDbContext _appDbContext;
        public ApplyController(IApplyJobService applyJobService, AppDbContext appDbContext)
        {
            _applyJobService = applyJobService;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int jobId)
        {
            try
            {
                var applications = await _applyJobService.GetAllApplicationsAsync();
                return View(applications);
            }
            catch (BaseException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Job");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Respond(int jobId)
        {
            var application = await _applyJobService.GetApplicationsByJobIdAsync(jobId);

            if (application == null || !application.Any())
            {
                TempData["Error"] = "Application not found.";
                return RedirectToAction("Index", new { jobId });
            }
            var firstApplication = application.FirstOrDefault();

            var responseDto = new RespondToApplyDTO
            {
                ApplyId = firstApplication.Id,
                ApplyName = firstApplication.Name,
                ApplyEmail = firstApplication.Email
            };
            return View(responseDto);
        }

        [HttpPost]
        public async Task<IActionResult> RespondToApplication(RespondToApplyDTO dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please correct the errors in the form.";
                return RedirectToAction("Index", "Apply");
            }

            try
            {
                var application = await _appDbContext.ApplyJobs.FindAsync(dto.ApplyId);

                if (application == null)
                {
                    TempData["Error"] = "Application not found.";
                    return RedirectToAction("Index", "Apply");
                }

                application.Response = dto.Response;
                _appDbContext.Update(application);
                await _appDbContext.SaveChangesAsync();

                await _applyJobService.SendResponseEmailAsync(application, dto.Response);

                TempData["Success"] = "Response sent to applicant!";
                return RedirectToAction("Index", "Apply");  
            }
            catch (BaseException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Apply");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Refuse(int applyId)
        {
            try
            {
                var application = await _appDbContext.ApplyJobs.FindAsync(applyId);

                if (application == null)
                {
                    TempData["Error"] = "Application not found.";
                    return RedirectToAction("Index", "Apply");
                }
                _appDbContext.ApplyJobs.Remove(application);
                await _appDbContext.SaveChangesAsync();
                await _applyJobService.SendResponseEmailAsync(application, "Unfortunately, Your application was not accepted");

                TempData["Success"] = "Application refused and deleted successfully.";
                return RedirectToAction("Index", "Apply");
            }
            catch (BaseException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Apply");
            }
        }
    }
}
