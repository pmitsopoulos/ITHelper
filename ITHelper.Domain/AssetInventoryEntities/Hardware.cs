using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.AssetInventoryEntities
{
    
    public class Hardware : BaseDomainEntity
    {
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        public int HardwareTypeId { get; set; }
        public virtual HardwareType HardwareType { get; set; }

        public string Model { get; set; }

        public bool IsOperational { get; set; }

        public string SerialNumber { get; set; }

        public DateTime InitializationDate { get; set; }

        public int HardwareSpecificationId { get; set; }
        public virtual HardwareSpecification HardwareSpecification { get; set; }

        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public string Description { get; set; }
        public string Comments { get; set; }

        public bool IsAssigned { get; set; }

        public virtual Asset Asset { get; set; }


    }
}
