

using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs
{
    public class UserDto : BaseDto
    {

        public UserDto()
        {
            Assets = new List<HardwareDto>();
        }
        public string Fullname { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public int DepartmentId { get; set; }
        public virtual DepartmentDto Department { get; set; }
        public ICollection<HardwareDto> Assets { get; set; }
    }
}
