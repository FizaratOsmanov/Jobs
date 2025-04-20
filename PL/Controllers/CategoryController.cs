using BL.DTOs.CategoryDTOs;
using BL.DTOs.JobDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Services.Implementations;
using CORE.Models;
using DATA.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;
        readonly IJobService _jobService;
        readonly AppDbContext _appDbContext;
        public CategoryController(ICategoryService categoryService, AppDbContext appDbContext, IJobService jobService)
        {
            _categoryService = categoryService;
            _appDbContext = appDbContext;
            _jobService = jobService;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<HomeGetCategoryDTO> categoryDTOs=await  _categoryService.GetCategoryHomeItemsAsync();
            ICollection<Job> jobs=_appDbContext.Jobs.ToList();
            if (jobs == null)
            {
                throw new BaseException("Something went wrong");
            }
            var model = categoryDTOs.Select(category => new HomeGetCategoryDTO
            {
                Title = category.Title,
                VacancyCount = jobs.Where(job => job.CategoryId == category.Id).Sum(job => job.VacancyCount)
            }).ToList();
            return View(model);
        }

        public async Task<IActionResult> JobsByCategory(int categoryId)
        {

            if (categoryId <= 0)
            {
                return BadRequest("Invalid Category ID");
            }
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);

            ICollection<JobListDTO> jobList = await _jobService.GetJobsByCategoryAsync(categoryId);

            ViewBag.CategoryTitle = category.Title;
            return View(jobList);
        }
    }
}
