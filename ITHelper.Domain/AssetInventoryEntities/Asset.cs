using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.AssetInventoryEntities
{
    public class Asset : BaseDomainEntity
    {


        public int HardwareId { get; set; }
        public virtual Hardware Hardware { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

        public DateTime DateAssigned { get; set; }
        public DateTime DiscontinueDate { get; set; }

        public string Comments { get; set; }


    }
}
