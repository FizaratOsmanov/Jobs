namespace BL.DTOs.JobDTOs
{
    public record JobListDTO
    {
        public string CompanyIconPath { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string JobNature { get; set; } 
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public DateTime DateLine { get; set; }
    }
}
