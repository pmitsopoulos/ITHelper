using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.NetworkPortInfoDTOs.UsageTypeDTOs
{
    public class UsageTypeDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }

        public virtual IEnumerable<NetworkPortInformationDto> NetworkPortInformation { get; set; }
    }
}
