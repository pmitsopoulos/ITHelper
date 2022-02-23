using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs.Validators
{
    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        private readonly IContactRepository contactRepository;

        public UpdateContactDtoValidator(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
            Include(new GenericContactDtoValidator(this.contactRepository));
        }
    }
}
