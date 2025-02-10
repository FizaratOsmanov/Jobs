namespace BL.DTOs.SliderItemDTOs
{
    public class GetSliderItemDTO
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
