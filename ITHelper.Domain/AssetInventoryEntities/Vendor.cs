using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Hardware> AllHardware { get; set; }
    }
}
