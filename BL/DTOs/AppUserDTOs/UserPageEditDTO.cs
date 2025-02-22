using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BL.DTOs.AppUserDTOs
{
    public  record UserPageEditDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Photo { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
