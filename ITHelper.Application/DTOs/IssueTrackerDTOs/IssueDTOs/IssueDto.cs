using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs
{
    public class IssueDto : BaseDto
    {
       
        public int ApplicationSystemId { get; set; }
        public ApplicationSystemDto ApplicationSystem { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DueDate { get; set; }
        public string IssueDescription { get; set; }
        public string ActionsTaken { get; set; }
        public string SolutionComments { get; set; }
        public bool Resolved { get; set; }
    }
}
