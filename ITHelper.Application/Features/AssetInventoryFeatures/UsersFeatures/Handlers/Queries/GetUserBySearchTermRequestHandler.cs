using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;


namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Handlers.Queries
{
    public class GetUserBySearchTermRequestHandler : GenericGetBySearchTermRequestHandler<IUserRepository, UserDto, User>
    {
        public GetUserBySearchTermRequestHandler(IUserRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
