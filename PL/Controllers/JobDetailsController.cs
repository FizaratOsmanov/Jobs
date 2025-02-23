using AutoMapper;
using BL.DTOs.ApplyJobDTOs;
using BL.DTOs.JobDTOs;
using BL.Services.Abstractions;
using BL.Utilities;
using CORE.Enums;
using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace PL.Controllers
{
    public class JobDetailsController : Controller
    {
        readonly IJobService _jobService;
        readonly IMapper _mapper;
        readonly IApplyJobService _applyJobService;
        public JobDetailsController(IJobService jobService, IMapper mapper, IApplyJobService applyJobService)
        {
            _jobService = jobService;
            _mapper = mapper;
            _applyJobService = applyJobService;
        }
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                Job? job = await _jobService.GetJobByIdAsync(id);
                JobDetailDTO detailDTO = _mapper.Map<JobDetailDTO>(job);
                ViewData["JobNatureList"] = Enum.GetValues(typeof(JobNature))
                .Cast<JobNature>()
                .Select(jobN => new SelectListItem
                {
                    Value = ((int)jobN).ToString(),
                    Text = jobN.ToString()
                }).ToList();
                return View(detailDTO);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        public IActionResult Apply() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Apply(CreateApplyJobDTO applyJobDTO)
        {
            if (!ModelState.IsValid)
                return View(applyJobDTO);

            string cvFilename = await applyJobDTO.CV.SaveAsync("CVs");

            var applyJob = _mapper.Map<ApplyJob>(applyJobDTO);

            await _applyJobService.SendEmailAsync(applyJob, cvFilename);

            TempData["SuccessMessage"] = "Application submitted successfully.";
            return RedirectToAction("Apply");
        }
    }
}
