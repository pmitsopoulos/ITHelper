
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs
{
    public interface IUserDto
    {
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int DepartmentId { get; set; }
    }
}
