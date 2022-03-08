using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Requests.Queries
{
    public class GetHardwareRequest : IRequest<HardwareDto>
    {
        public int Id { get; set; }
    }
}
