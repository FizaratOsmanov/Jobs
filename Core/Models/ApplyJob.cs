using CORE.Models.Base;

namespace CORE.Models
{
    public class ApplyJob:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Portfolio { get; set; }
        public string CV { get; set; }
        public string CoverLetter { get; set; }
        public int JobId {  get; set; }
        public string? Response {  get; set; }
        public Job Job { get; set; }
    }
}
