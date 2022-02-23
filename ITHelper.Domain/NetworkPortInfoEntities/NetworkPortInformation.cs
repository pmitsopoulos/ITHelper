using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.NetworkPortInfoEntities
{
    public class NetworkPortInformation : BaseDomainEntity
    {
        public string PortNumber { get; set; }
        public string Protocol { get; set; }      
        public string UseDescription { get; set; }
        public string Comments { get; set; }
    }
}
