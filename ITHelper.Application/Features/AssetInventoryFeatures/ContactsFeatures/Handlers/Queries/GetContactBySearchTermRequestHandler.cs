using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;


namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Handlers.Queries
{
    public class GetContactsBySearchTermRequestHandler : GenericGetBySearchTermRequestHandler<IContactRepository, ContactDto, Contact>
    {
        public GetContactsBySearchTermRequestHandler(IContactRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
