using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Requests.Commands
{

    public class CreateUserRequest : IRequest<BaseResponse>
    {
        public CreateUserDto UserDto { get; set; }
    }
}
