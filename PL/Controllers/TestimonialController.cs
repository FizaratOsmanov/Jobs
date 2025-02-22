using System.Security.Claims;
using BL.DTOs.CommentDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace PL.Controllers
{
    public class TestimonialController : Controller
    {

        readonly ICommentService _commentService;
        readonly IAccountService _accountService;

        public TestimonialController(ICommentService commentService, IAccountService accountService)
        {
            _commentService = commentService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<GetCommentDTO> dto = await _commentService.GetAllCommentForViewAsync();               
                return View(dto);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }


        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentDTO dto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return Unauthorized(new { success = false, message = "User is not logged in." });
                }
                await _commentService.CreateCommentAsync(dto, userId);
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { success = false, message = "An unexpected error occurred." });
            }
        }

    }
}
