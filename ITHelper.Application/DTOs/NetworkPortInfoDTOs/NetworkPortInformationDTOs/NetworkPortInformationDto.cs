using ITHelper.Application.DTOs.NetworkPortInfoDTOs.UsageTypeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs
{
    public class NetworkPortInformationDto : BaseDto
    {
        public string PortNumber { get; set; }
        public int UsageTypeId { get; set; }
        public UsageTypeDto UsageType { get; set; }
        public bool TCP { get; set; }
        public string UseDescription { get; set; }
    }
}
