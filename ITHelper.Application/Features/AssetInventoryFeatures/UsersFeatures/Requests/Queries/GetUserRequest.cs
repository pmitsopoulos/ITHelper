using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Requests.Queries
{
    public class GetUserRequest : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
