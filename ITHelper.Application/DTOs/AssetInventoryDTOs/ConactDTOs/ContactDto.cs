
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.ConactDTOs
{
    public class ContactDto : BaseDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public virtual ICollection<HardwareDto> AllHardware { get; set; }
    }
}
