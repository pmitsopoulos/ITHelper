using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.NetworkPortInfoEntities
{
    public class UsageType : BaseDomainEntity
    {
        public UsageType()
        {
            NetworkPortInformation = new List<NetworkPortInformation>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }

        public virtual IEnumerable<NetworkPortInformation> NetworkPortInformation { get; set; }
    }
}
