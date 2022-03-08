using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Requests.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Handlers.Queries
{
    public class GetUserBySearchTermRequestHandler : IRequestHandler<GetUserBySearchTermRequest, List<UserDto>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserBySearchTermRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetUserBySearchTermRequest request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetBySearchTermAsync(request.SearchTerm);
            
            if(users==null)
            {
                throw new NotFoundException(nameof(User), request.SearchTerm);
            }
            return mapper.Map<List<UserDto>>(users);
        }
    }
}
