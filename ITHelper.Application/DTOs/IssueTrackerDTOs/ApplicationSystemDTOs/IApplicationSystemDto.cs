using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs
{
    public interface IApplicationSystemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SystemContactId { get; set; }
    }
}
