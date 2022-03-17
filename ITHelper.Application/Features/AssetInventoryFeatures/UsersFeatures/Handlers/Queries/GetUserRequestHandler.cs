using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;


namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Handlers.Queries
{
    public class GetUserRequestHandler : GenericGetByIdRequestHandler<IUserRepository, UserDto, User>
    {
        public GetUserRequestHandler(IUserRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
