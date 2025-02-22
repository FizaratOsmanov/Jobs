using CORE.Enums;
using CORE.Models;

namespace BL.DTOs.JobDTOs
{
    public record JobListDTO
    {
        public int Id { get; set; }
        public string CompanyIconPath { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public JobNature JobNature { get; set; } 
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public DateTime DateLine { get; set; }

        public Category Category { get; set; }
    }
}
