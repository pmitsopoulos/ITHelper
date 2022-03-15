using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.AssetInventoryEntities
{
    public class Contact : BaseDomainEntity
    {
        public Contact()
        {
            AllHardware = new List<Hardware>();
        }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Hardware> AllHardware { get; set; }
    }
}
