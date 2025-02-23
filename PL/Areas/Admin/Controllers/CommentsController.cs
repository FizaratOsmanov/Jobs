using BL.DTOs.CommentDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentsController : Controller
    {
        readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async  Task<IActionResult> Index()
        {
            ICollection<AdminGetCommentDTO> comment = await _commentService.GetAllCommentForAdminAsync();
            return View(comment);
        }


        [HttpPost]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _commentService.SoftDeleteCommentAsync(id);
            }
            catch (BaseException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> HardDelete(int id)
        {
            try
            {
                await _commentService.HardDeleteCommentAsync(id);
            }
            catch (BaseException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
