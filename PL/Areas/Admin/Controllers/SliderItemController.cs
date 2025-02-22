using AutoMapper;
using BL.DTOs.SliderItemDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderItemController : Controller
    {
        readonly ISliderItemService _sliderItemService;
        readonly IMapper _mapper;
        public SliderItemController(ISliderItemService sliderItemService,IMapper mapper)
        {
            _sliderItemService = sliderItemService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<GetSliderItemDTO> dto = await _sliderItemService.GetAllSliderItemAsync();
                return View(dto);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSliderItemDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _sliderItemService.CreateSliderItemAsync(dto);
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
                var sliderItem = await _sliderItemService.GetSliderItemByIdAsync(id);
                UpdateSliderItemDTO updateDto = _mapper.Map<UpdateSliderItemDTO>(sliderItem);
                return View(updateDto);
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
        public async Task<IActionResult> Update(UpdateSliderItemDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _sliderItemService.UpdateSliderItemAsync(dto);
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
                await _sliderItemService.SoftDeleteSliderItemAsync(id);
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
                await _sliderItemService.HardDeleteSliderItemAsync(id);
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
                return View(await _sliderItemService.GetSliderItemByIdAsync(id));
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
