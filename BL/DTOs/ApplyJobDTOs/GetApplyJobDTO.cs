namespace BL.DTOs.ApplyJobDTOs
{
    public class GetApplyJobDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Portfolio { get; set; }
        public string CV { get; set; }
        public string CoverLetter { get; set; }

        public int JobId { get; set; }
    }
}
