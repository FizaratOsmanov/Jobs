using BL.DTOs.JobDTOs;
using BL.Services.Abstractions;
using CORE.Enums;
using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PL.Controllers
{
    public class JobListController : Controller
    {
        readonly IJobService _jobService;
        readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        public JobListController(IJobService jobService,
            UserManager<AppUser> userManager,ICategoryService categoryService)
        {
            _jobService = jobService;          
            _userManager = userManager;
            _categoryService = categoryService;
        }
        //public async Task<IActionResult> Index(bool showAllAll = false, bool showAllFullTime = false, bool showAllPartTime = false)
        //{
        //    try
        //    {
        //        ICollection<JobListDTO> dto = await _jobService.GetJobForListViewAsync();

        //        var allJobs = dto.ToList();
        //        ViewBag.TotalAllJobs = allJobs.Count;
        //        ViewBag.ShowAllAll = showAllAll;
        //        if (!showAllAll) allJobs = allJobs.Take(5).ToList();

        //        var fullTimeJobs = dto.Where(j => j.JobNature.ToString() == "FullTime").ToList();
        //        ViewBag.TotalFullTimeJobs = fullTimeJobs.Count;
        //        ViewBag.ShowAllFullTime = showAllFullTime;
        //        if (!showAllFullTime) fullTimeJobs = fullTimeJobs.Take(5).ToList();

        //        var partTimeJobs = dto.Where(j => j.JobNature.ToString() == "PartTime").ToList();
        //        ViewBag.TotalPartTimeJobs = partTimeJobs.Count;
        //        ViewBag.ShowAllPartTime = showAllPartTime;
        //        if (!showAllPartTime) partTimeJobs = partTimeJobs.Take(5).ToList();

        //        ViewBag.AllJobs = allJobs;
        //        ViewBag.FullTimeJobs = fullTimeJobs;
        //        ViewBag.PartTimeJobs = partTimeJobs;
        //        ViewData["JobNatureList"] = Enum.GetValues(typeof(JobNature))
        //            .Cast<JobNature>()
        //            .Select(jobN => new SelectListItem
        //            {
        //                Value = ((int)jobN).ToString(),
        //                Text = jobN.ToString()
        //            }).ToList();

        //        return View(dto);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Something went wrong!");
        //    }
        //}

        public async Task<IActionResult> Index(
    bool showAllAll = false,
    bool showAllFullTime = false,
    bool showAllPartTime = false,
    decimal? minSalary = null,
    decimal? maxSalary = null)
        {
            try
            {
                ICollection<JobListDTO> dto = await _jobService.GetJobForListViewAsync();

                // Maaş aralığına görə filtr etmə
                if (minSalary.HasValue)
                {
                    dto = dto.Where(job => job.MinSalary >= minSalary.Value).ToList();
                }

                if (maxSalary.HasValue)
                {
                    dto = dto.Where(job => job.MaxSalary <= maxSalary.Value).ToList();
                }

                // Bütün işləri, FullTime və PartTime işləri əldə edirik
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

                // ViewBag-a işləri əlavə edirik
                ViewBag.AllJobs = allJobs;
                ViewBag.FullTimeJobs = fullTimeJobs;
                ViewBag.PartTimeJobs = partTimeJobs;

                // Job Nature Listəsi
                ViewData["JobNatureList"] = Enum.GetValues(typeof(JobNature))
                    .Cast<JobNature>()
                    .Select(jobN => new SelectListItem
                    {
                        Value = ((int)jobN).ToString(),
                        Text = jobN.ToString()
                    }).ToList();

                // `minSalary` və `maxSalary` parametrlərini ViewBag-a göndəririk
                ViewBag.MinSalary = minSalary;
                ViewBag.MaxSalary = maxSalary;

                return View(dto);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }


        public async Task<IActionResult> ByCategory(int categoryId, int page = 1)
        {
            if (categoryId == 0)
            {
                return RedirectToAction("Index"); 
            }

            var category = await _categoryService.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                ViewBag.ErrorMessage = "Kateqoriya tapılmadı."; 
                return View("Error"); 
            }

            int pageSize = 5;
            var jobs = await _jobService.GetJobsByCategoryAsync(categoryId);

            var paginatedJobs = jobs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)jobs.Count / pageSize);
            ViewBag.CategoryId = categoryId;

            return View("ByCategory", jobs); 
        }

    }
}
