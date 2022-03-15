using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.AssetInventoryEntities
{
    
    public class Hardware : BaseDomainEntity
    {
        [Required]
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        [Required]
        public int HardwareTypeId { get; set; }
        public virtual HardwareType HardwareType { get; set; }

        [Required]
        public string Model { get; set; }

        public bool IsOperational { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        public DateTime InitializationDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime DiscontinueDate { get; set; }

        [Required]
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public string Description { get; set; }
        public string Comments { get; set; }

    }
}
