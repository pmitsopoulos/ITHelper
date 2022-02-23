
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs
{
    public class HardwareDto : BaseDto
    {
        public int VendorId { get; set; }
        public virtual VendorDto Vendor { get; set; }

        public int HardwareTypeId { get; set; }
        public virtual HardwareTypeDto HardwareType { get; set; }

        public string Model { get; set; }

        public bool IsOperational { get; set; }

        public string SerialNumber { get; set; }

        public DateTime InitializationDate { get; set; }

        public int ContactId { get; set; }
        public virtual ContactDto Contact { get; set; }

        public string Description { get; set; }
        public string Comments { get; set; }

        public int UserId { get; set; }
        public virtual UserDto User { get; set; }

        public int DepartmentId { get; set; }
        public virtual DepartmentDto Department { get; set; }
        public int SiteId { get; set; }
        public virtual SiteDto Site { get; set; }

        public DateTime DateAssigned { get; set; }
        public DateTime DiscontinueDate { get; set; }
    }
}
