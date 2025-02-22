using AutoMapper;
using BL.DTOs.JobDTOs;
using BL.Services.Abstractions;
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
        public JobDetailsController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
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
    }
}
