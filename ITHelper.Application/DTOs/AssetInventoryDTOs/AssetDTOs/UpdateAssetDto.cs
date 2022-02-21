using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.AssetDTOs
{
    public class UpdateAssetDto : BaseDto
    {
        public int HardwareId { get; set; }  
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public int SiteId { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime DiscontinueDate { get; set; }
        public string Comments { get; set; }
    }
}
