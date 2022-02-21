using ITHelper.Application.DTOs.AssetInventoryDTOs.AssetDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs
{
    public class SiteDto
    {
        public SiteDto()
        {
            Users = new List<UserDto>();
            Assets = new List<AssetDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
        public virtual ICollection<AssetDto> Assets { get; set; }
    }
}
