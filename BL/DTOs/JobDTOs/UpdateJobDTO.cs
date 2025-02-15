using Microsoft.AspNetCore.Http;

namespace BL.DTOs.JobDTOs
{
    public record UpdateJobDTO
    {
        public int Id { get; set; }
        public IFormFile CompanyIcon { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public string Description { get; set; }
        public string Responsiblity { get; set; }

        public int VacancyCount { get; set; }
        public string Qualification { get; set; }
        public DateTime DateLine { get; set; }
        public string CompanyDetail { get; set; }
        public int CategoryId { get; set; }
    }
}
