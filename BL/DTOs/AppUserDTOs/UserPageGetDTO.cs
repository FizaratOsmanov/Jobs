using CORE.Enums;

namespace BL.DTOs.AppUserDTOs
{
    public record UserPageGetDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoPath { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public RoleEnum Role { get; set; }
    }
}
