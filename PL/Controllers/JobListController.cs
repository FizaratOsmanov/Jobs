using BL.DTOs.JobDTOs;
using BL.Services.Abstractions;
using CORE.Enums;
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
        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<JobListDTO> dto = await _jobService.GetJobForListViewAsync();
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
