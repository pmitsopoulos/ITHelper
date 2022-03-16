using AutoMapper;
using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs.Validators;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Requests.Commands;
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
    public class UpdateContactRequestHandler
        : GenericUpdateRequestHandler<IUnitOfWork, IContactRepository, UpdateContactDto, Contact, UpdateContactDtoValidator>
    {
        public UpdateContactRequestHandler(IUnitOfWork genericUnitOfWork, IMapper mapper,
            IContactRepository repository, UpdateContactDtoValidator validator) 
            : base(genericUnitOfWork, mapper, repository, validator)
        {
        }
    }
}
