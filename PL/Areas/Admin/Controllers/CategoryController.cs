using BL.DTOs.CategoryDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CategoryController : Controller
{
    readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<IActionResult> Index()
    {
        IEnumerable<AdminGetCategoryDTO> dto = await _categoryService.GetCategoryAdminItemsAsync();

        return View(dto);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCategoryDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        try
        {
            await _categoryService.CreateCategoryAsync(dto);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Update(int id)
    {
        try
        {
            return View(await _categoryService.GetCategoryByIdForUpdateAsync(id));
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
    public async Task<IActionResult> Update(UpdateCategoryDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        try
        {
            await _categoryService.UpdateCategoryAsync(dto);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }
    public async Task<IActionResult> SoftDelete(int id)
    {
        try
        {
            await _categoryService.SoftDeleteCategoryAsync(id);
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
            await _categoryService.HardDeleteCategoryAsync(id);
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
            return View(await _categoryService.GetCategoryByIdWithJobAsync(id));
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
