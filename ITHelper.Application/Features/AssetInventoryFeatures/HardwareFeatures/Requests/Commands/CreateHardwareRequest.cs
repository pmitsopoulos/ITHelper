using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Requests.Commands
{
    public class CreateHardwareRequest : IRequest<BaseResponse>
    {
        public CreateHardwareDto HardwareDto { get; set; }
    }
}
