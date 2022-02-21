using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs
{
    public class VendorDto : BaseDto
    {

        public VendorDto()
        {
            AllHardware = new List<HardwareDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<HardwareDto> AllHardware { get; set; }
    }
}
