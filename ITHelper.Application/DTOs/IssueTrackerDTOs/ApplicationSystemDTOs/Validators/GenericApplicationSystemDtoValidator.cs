using FluentValidation;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs.Validators
{
    public class GenericApplicationSystemDtoValidator : AbstractValidator<IApplicationSystemDto>
    {
        private readonly IApplicationSystemRepository applicationSystemRepository;

        public GenericApplicationSystemDtoValidator(IApplicationSystemRepository applicationSystemRepository)
        {
            this.applicationSystemRepository = applicationSystemRepository;
            RuleFor(a => a.Name).NotNull().NotEmpty().WithMessage("The application system name is required");
            RuleFor(a => a.SystemContactId).NotEqual(default(int)).WithMessage("The system must be registered to a system contact.");
        }
    }
}
