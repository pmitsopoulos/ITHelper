using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Fullname { get; set; }
     
        public string Comments { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<ApplicationSystem> ApplicationSystems { get; set; }

    }
}
