using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.IssueTrackerEntities
{
    public class SystemContact : BaseDomainEntity
    {
        public SystemContact()
        {
            ApplicationSystems = new List<ApplicationSystem>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Comments { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<ApplicationSystem> ApplicationSystems { get; set; }

    }
}
