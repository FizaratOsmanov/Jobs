using AutoMapper;
using BL.DTOs.ApplyJobDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Utilities;
using CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ApplyJobController : Controller
    {
        private readonly IApplyJobService _applyJobService;
        private readonly IMapper _mapper;

        public ApplyJobController(IApplyJobService applyJobService, IMapper mapper)
        {
            _applyJobService = applyJobService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Apply(int jobId)
        {
            var model = new CreateApplyJobDTO { JobId = jobId };
            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Apply(CreateApplyJobDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                string cvFilename = await dto.CV.SaveAsync("CVs");

                ApplyJob applyJob = _mapper.Map<ApplyJob>(dto);
                applyJob.CV = cvFilename; 

                await _applyJobService.SendEmailAsync(applyJob, cvFilename);


                TempData["Success"] = "Müraciətiniz uğurla göndərildi!";
                return RedirectToAction("Index", "Job", new { id = dto.JobId });
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dto);
            }
        }

















        // ✅ Müəyyən bir işin müraciətlərini silmək üçün
        [HttpPost]
        public async Task<IActionResult> DeleteApplications(int jobId)
        {
            try
            {
                await _applyJobService.DeleteApplicationsByJobIdAsync(jobId);
                TempData["Success"] = "Müraciətlər uğurla silindi!";
            }
            catch (BaseException ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("JobApplications", new { jobId });
        }










        // ✅ Müəyyən bir işə edilən bütün müraciətləri göstərir (Admin Panel üçün)
        [HttpGet]
        public async Task<IActionResult> JobApplications(int jobId)
        {
            try
            {
                var applications = await _applyJobService.GetApplicationsByJobIdAsync(jobId);
                return View(applications);
            }
            catch (BaseException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Job");
            }
        }
    }
}
