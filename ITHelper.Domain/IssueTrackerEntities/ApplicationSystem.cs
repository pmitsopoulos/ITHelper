using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int SystemContactId { get; set; }
        public virtual SystemContact SystemContact { get; set; }
        public virtual IEnumerable<Issue> Issues { get; set; }
    }
}
