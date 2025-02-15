namespace BL.DTOs.CategoryDTOs
{
    public record HomeGetCategoryDTO
    {
        public string Title { get; set; }

        public int VacancyCount { get; set; }
    }
}
