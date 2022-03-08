using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Requests.Commands
{
    public class CreateHardwareTypeRequest : IRequest<BaseResponse>
    {
        public CreateHardwareTypeDto HardwareTypeDto { get; set; }
    }
}
