namespace BL.DTOs.CommentDTOs
{
    public  record  AdminGetCommentDTO
    {
        public int Id { get; set; }
        public  string Message { get; set; }
    }
}
