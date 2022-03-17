using AutoMapper;
using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Contracts.Persistence.AssetInventory;

using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Handlers.Commands
{
    public class DeleteContactRequestHandler : GenericDeleteRequestHandler<IUnitOfWork, IContactRepository, Contact>
    {
        public DeleteContactRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IContactRepository repository) 
            : base(unitOfWork, mapper, repository)
        {
        }
    }
}
