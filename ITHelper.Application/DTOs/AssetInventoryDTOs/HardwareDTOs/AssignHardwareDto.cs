using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs
{
    public class AssignHardwareDto : BaseDto
    {
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateAssigned { get; set; }
    }
}
