using Microsoft.AspNetCore.Http;

namespace BL.DTOs.SliderItemDTOs
{
    public class CreateSliderItemDTO
    {
        public IFormFile Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }


}
