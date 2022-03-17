using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Handlers.Queries
{
    public class GetAllUsersRequestHandler : GenericGetAllRequestHandler<IUserRepository, UserDto, User>
    {
        public GetAllUsersRequestHandler(IUserRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
