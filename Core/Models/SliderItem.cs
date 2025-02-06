using CORE.Models.Base;

namespace CORE.Models
{
    public  class SliderItem:BaseEntity
    {
        public string? ImgPath { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
