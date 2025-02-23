namespace BL.DTOs.CommentDTOs
{
    public record GetCommentDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string PhotoPath { get; set; }
        public string FirstName { get; set; }
        public string Profession { get; set; }
        public bool IsDeleted { get; set; }

    }
}
