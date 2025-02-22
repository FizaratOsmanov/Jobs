using BL.DTOs.JobDTOs;
using BL.Services.Abstractions;
using CORE.Enums;
using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PL.Controllers
{
    public class JobListController : Controller
    {
        readonly IJobService _jobService;
        public JobListController(IJobService jobService)
        {
            _jobService = jobService;          
        }
        public async Task<IActionResult> Index(bool showAllAll = false, bool showAllFullTime = false, bool showAllPartTime = false)
        {
            try
            {
                ICollection<JobListDTO> dto = await _jobService.GetJobForListViewAsync();

                var allJobs = dto.ToList();
                ViewBag.TotalAllJobs = allJobs.Count;
                ViewBag.ShowAllAll = showAllAll;
                if (!showAllAll) allJobs = allJobs.Take(5).ToList();


                var fullTimeJobs = dto.Where(j => j.JobNature.ToString() == "FullTime").ToList();
                ViewBag.TotalFullTimeJobs = fullTimeJobs.Count;
                ViewBag.ShowAllFullTime = showAllFullTime;
                if (!showAllFullTime) fullTimeJobs = fullTimeJobs.Take(5).ToList();


                var partTimeJobs = dto.Where(j => j.JobNature.ToString() == "PartTime").ToList();
                ViewBag.TotalPartTimeJobs = partTimeJobs.Count;
                ViewBag.ShowAllPartTime = showAllPartTime;
                if (!showAllPartTime) partTimeJobs = partTimeJobs.Take(5).ToList();

                ViewBag.AllJobs = allJobs;
                ViewBag.FullTimeJobs = fullTimeJobs;
                ViewBag.PartTimeJobs = partTimeJobs;

                ViewData["JobNatureList"] = Enum.GetValues(typeof(JobNature))
                .Cast<JobNature>()
                .Select(jobN => new SelectListItem
                {
                    Value = ((int)jobN).ToString(),
                    Text = jobN.ToString()
                }).ToList();

                return View(dto);
            }
            catch (Exception) 
            {
                return BadRequest("Something went wrong!");
            }
        }
    }
}
