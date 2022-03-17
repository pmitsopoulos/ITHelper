using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;

using ITHelper.Domain.AssetInventoryEntities;


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
