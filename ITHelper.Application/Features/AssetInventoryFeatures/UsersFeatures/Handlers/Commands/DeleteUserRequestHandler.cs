using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;


namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Handlers.Commands
{
    public class DeleteUserRequestHandler : GenericDeleteRequestHandler<IUnitOfWork, IUserRepository, User>
    {
        public DeleteUserRequestHandler(IUnitOfWork genericUnitOfWork, IMapper mapper, IUserRepository repository) 
            : base(genericUnitOfWork, mapper, repository)
        {
        }
    }
}
