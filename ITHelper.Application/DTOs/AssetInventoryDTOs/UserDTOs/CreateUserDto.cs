using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs
{
    public class CreateUserDto
    {
       
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int SiteId { get; set; }
    }
}
