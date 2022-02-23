using FluentValidation;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs.Validators
{
    public  class GenericIssueDtoValidator : AbstractValidator<IIssueDto>
    {
        private readonly IIssueRepository issueRepository;

        public GenericIssueDtoValidator(IIssueRepository issueRepository)
        {
            this.issueRepository = issueRepository;
            RuleFor(i => i.IssueDescription).NotNull().NotEmpty().WithMessage("Issue Description is required");
            RuleFor(i => i.ApplicationSystemId).NotEqual(default(int)).WithMessage("Issue must be registered to a category.");
            RuleFor(i => i.Resolved).Equal(true).WithMessage("Issue Description is required");
            RuleFor(i => i.SolutionComments).NotEmpty().NotNull().When(r => r.Resolved==true).WithMessage("Solution comments are required if the issue is resolved.");
            RuleFor(i => i.ActionsTaken).NotEmpty().NotNull().When(r => r.Resolved == true).WithMessage("Actions that were taken are required if the issue is resolved.");
        }
    }
}
