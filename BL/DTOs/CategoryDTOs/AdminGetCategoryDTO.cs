namespace BL.DTOs.CategoryDTOs
{
    public record AdminGetCategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

    }
}
