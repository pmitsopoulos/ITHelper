using FluentValidation;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs.Validators
{
    public class GenericSystemContactDtoValidator : AbstractValidator<ISystemContactDto>
    {
        private readonly ISystemContactRepository systemContactRepository;

        public GenericSystemContactDtoValidator(ISystemContactRepository systemContactRepository)
        {
            this.systemContactRepository = systemContactRepository;
            RuleFor(sc => sc.Fullname).NotNull().NotEmpty().WithMessage("The contact fullname is required.");
            RuleFor(sc => sc.PhoneNumber).NotNull().NotEmpty().WithMessage("The contact phone number is required.");
            RuleFor(sc => sc.Email).NotNull().NotEmpty().WithMessage("The contact email is required.");
            
        }
    }
}
