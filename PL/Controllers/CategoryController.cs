using BL.DTOs.CategoryDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Models;
using DATA.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;
        readonly AppDbContext _appDbContext;
        public CategoryController(ICategoryService categoryService, AppDbContext appDbContext)
        {
            _categoryService = categoryService;
            _appDbContext = appDbContext;
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
                VacancyCount = jobs.Where(job => job.CategoryId == category.Id).Sum(job => job.VacancyCount ?? 0)
            }).ToList();
            return View(model);
        }
    }
}
