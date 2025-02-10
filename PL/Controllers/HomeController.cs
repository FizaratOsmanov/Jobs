using BL.DTOs.SliderItemDTOs;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        readonly ISliderItemService sliderItemService;
        public HomeController(ISliderItemService sliderItemService)
        {
            this.sliderItemService = sliderItemService;
        }
        public async  Task<IActionResult> Index()
        {
            ICollection<GetSliderItemDTO> dto =await  sliderItemService.GetAllSliderItemAsync(); 
            return View(dto);
        }
    }
}
