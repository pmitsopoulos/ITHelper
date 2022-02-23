using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs
{
    public class CreateIssueDto : IIssueDto
    {
        public CreateIssueDto()
        {
            DateIssued = DateTime.Now;
            DueDate = DateIssued.AddDays(2);
        }
        public int ApplicationSystemId { get; set; }
        public string IssueDescription { get; set; }
        public string ActionsTaken { get; set; }
        public string SolutionComments { get; set; }
        public bool Resolved { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DueDate { get; set; }
    }
}
