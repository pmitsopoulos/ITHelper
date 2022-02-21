using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.AssetInventoryEntities
{
    public class User : BaseDomainEntity
    {
        public User()
        {
            Assets = new List<Asset>();
        }
        public string Fullname { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
