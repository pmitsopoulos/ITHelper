using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs
{
    public class SystemContactDto : BaseDto
    {
        public SystemContactDto()
        {
            ApplicationSystems = new List<ApplicationSystemDto>();
        }
        public string Fullname { get; set; }
        
        public string Comments { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<ApplicationSystemDto> ApplicationSystems { get; set; }
    }
}
