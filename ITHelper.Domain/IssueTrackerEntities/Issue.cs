using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.IssueTrackerEntities
{
    public class Issue : BaseDomainEntity
    {
        [Required]
        public int ApplicationSystemId { get; set; }
        public virtual ApplicationSystem ApplicationSystem { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public string IssueDescription { get; set; }
        public string ActionsTaken { get; set; }
        public string SolutionComments { get; set; }
        public bool Resolved { get; set; }

    }
}
