using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs
{
    public class CreateNetworkPortInformationDto
    {
        public string PortNumber { get; set; }
        public int UsageTypeId { get; set; }
        public bool TCP { get; set; }
        public string UseDescription { get; set; }
    }
}
