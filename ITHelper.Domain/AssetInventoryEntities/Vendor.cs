using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.AssetInventoryEntities
{
    public class Vendor : BaseDomainEntity
    {
        public Vendor()
        {
            AllHardware = new List<Hardware>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Hardware> AllHardware { get; set; }
    }
}
