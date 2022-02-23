using FluentValidation;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs.Validators
{
    public class CreateIssueDtoValidator : AbstractValidator<CreateIssueDto> 
    {
        private readonly IIssueRepository issueRepository;

        public CreateIssueDtoValidator(IIssueRepository issueRepository)
        {
            this.issueRepository = issueRepository;
            Include(new GenericIssueDtoValidator(this.issueRepository));
            RuleFor(i => i.DueDate).GreaterThanOrEqualTo(i => i.DateIssued).WithMessage("The due date of an issue must be the same or later than the issued date");
        }
    }
}
