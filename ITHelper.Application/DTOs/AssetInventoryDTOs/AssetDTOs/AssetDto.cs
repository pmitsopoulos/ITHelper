using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.AssetDTOs
{
   public class AssetDto : BaseDto
    {
        public int HardwareId { get; set; }
        public virtual HardwareDto Hardware { get; set; }

        public int UserId { get; set; }
        public virtual UserDto User { get; set; }

        public int DepartmentId { get; set; }
        public virtual DepartmentDto Department { get; set; }
        public int SiteId { get; set; }
        public virtual SiteDto Site { get; set; }

        public DateTime DateAssigned { get; set; }
        public DateTime DiscontinueDate { get; set; }

        public string Comments { get; set; }
    }
}
