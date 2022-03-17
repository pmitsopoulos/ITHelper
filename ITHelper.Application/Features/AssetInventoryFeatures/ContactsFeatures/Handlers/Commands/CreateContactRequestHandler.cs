using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Handlers.Commands
{
    public class CreateContactRequestHandler : GenericCreateRequestHandler<IUnitOfWork, CreateContactDto, Contact, IContactRepository, CreateContactDtoValidator>
    {
        public CreateContactRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IContactRepository repository, CreateContactDtoValidator validator)
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
