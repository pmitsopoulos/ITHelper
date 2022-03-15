using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Models.FilterModels.IssueTrackerFilterModels
{
    public class IssueFilterModel
    {
        public int ApplicationSystemId { get; set; }
        public bool Resolved { get; set; }
        public bool Expired { get; set; }
    }
}
