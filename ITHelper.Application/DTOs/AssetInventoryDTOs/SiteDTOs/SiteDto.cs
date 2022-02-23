
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs
{
    public class SiteDto : BaseDto
    {
        public SiteDto()
        {
            Users = new List<UserDto>();
            Assets = new List<HardwareDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
        public virtual ICollection<HardwareDto> Assets { get; set; }
    }
}
