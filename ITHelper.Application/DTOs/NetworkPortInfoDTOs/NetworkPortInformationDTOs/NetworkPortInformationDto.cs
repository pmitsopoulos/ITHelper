
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
        public string Protocol { get; set; }
        public string UseDescription { get; set; }
    }
}
