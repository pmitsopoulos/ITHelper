using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Handlers.Commands
{
    public class NewCreateContactRequestHandler 
        : GenericCreateRequestHandler<IUnitOfWork, CreateContactDto, Contact, IContactRepository, CreateContactDtoValidator>
    {
        public NewCreateContactRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IContactRepository repository, CreateContactDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
