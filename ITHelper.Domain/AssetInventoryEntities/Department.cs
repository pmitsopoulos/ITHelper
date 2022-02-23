using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.AssetInventoryEntities
{
    public class Department : BaseDomainEntity
    {

        public Department()
        {
            Users = new List<User>();
            Assets = new List<Hardware>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Hardware> Assets { get; set; }
    }
}
