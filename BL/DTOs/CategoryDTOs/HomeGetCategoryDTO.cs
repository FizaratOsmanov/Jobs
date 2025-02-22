namespace BL.DTOs.CategoryDTOs
{
    public record HomeGetCategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int VacancyCount { get; set; }
    }
}
