using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs
{
    public class ApplicationSystemDto : BaseDto
    {
        public ApplicationSystemDto()
        {
            Issues = new List<IssueDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SystemContactId { get; set; }
        public SystemContactDto SystemContact { get; set; }
        public virtual IEnumerable<IssueDto> Issues { get; set; }
    }
}
