using FluentValidation;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs.Validators
{
    public class UpdateIssueDtoValidator : AbstractValidator<UpdateIssueDto>
    {
        private readonly IIssueRepository issueRepository;

        public UpdateIssueDtoValidator(IIssueRepository issueRepository)
        {
            this.issueRepository = issueRepository;
            Include(new GenericIssueDtoValidator(this.issueRepository));
            
        }
    }
}
