namespace BL.DTOs.JobDTOs;

public record AdminGetJobDTO
{
    public int Id { get; set; }
    public string CompanyIconPath { get; set; }
    public string Title { get; set; }       
    public string JobNature { get; set; }
    public string CategoryTitle { get; set; }
    public bool IsDeleted { get; set; }

}
