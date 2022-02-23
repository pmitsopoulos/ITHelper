using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs.Validators
{
    public  class GenericContactDtoValidator : AbstractValidator<IContactDto>
    {
        private readonly IContactRepository contactRepository;

        public GenericContactDtoValidator(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("The Contact name is required");
            RuleFor(c => c.PhoneNumber).NotEmpty().NotNull().WithMessage("Phone Number is required");
            RuleFor(c => c.EmailAddress).NotEmpty().NotNull().WithMessage("Email address is required");
            
        }
    }
}
