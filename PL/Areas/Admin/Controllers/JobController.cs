using BL.DTOs.JobDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobController : Controller
    {
        readonly ICategoryService _categoryService;
        readonly IJobService _jobService;
        public JobController(ICategoryService categoryService,IJobService jobService)
        {
            _categoryService = categoryService;
            _jobService = jobService;      
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<AdminGetJobDTO> dto = await _jobService.GetJobAdminItemsAsync();
                return View(dto);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryAdminItemsAsync(), "Id", "Title");
                return View();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateJobDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryAdminItemsAsync(), "Id", "Title");
                return View(dto);
            }

            try
            {
                await _jobService.CreateJobAsync(dto);
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryAdminItemsAsync(), "Id", "Title");
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryAdminItemsAsync(), "Id", "Title");
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(dto);
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryAdminItemsAsync(), "Id", "Title");
                return View(await _jobService.GetJobByIdForUpdateAsync(id));
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateJobDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryAdminItemsAsync(), "Id", "Title");
                return View(dto);
            }

            try
            {
                await _jobService.UpdateJobAsync(dto);
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryAdminItemsAsync(), "Id", "Title");
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryAdminItemsAsync(), "Id", "Title");
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(dto);
            }
        }

        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _jobService.SoftDeleteJobAsync(id);
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            try
            {
                await _jobService.HardDeleteJobAsync(id);
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return View(await _jobService.GetJobByIdAsync(id));
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }
    }
}
