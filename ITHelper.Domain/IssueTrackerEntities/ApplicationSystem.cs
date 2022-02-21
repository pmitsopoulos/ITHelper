using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.IssueTrackerEntities
{
    public class ApplicationSystem : BaseDomainEntity
    {
        public ApplicationSystem()
        {
            Issues = new List<Issue>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SystemContactId { get; set; }
        public virtual SystemContact SystemContact { get; set; }
        public virtual IEnumerable<Issue> Issues { get; set; }
    }
}
