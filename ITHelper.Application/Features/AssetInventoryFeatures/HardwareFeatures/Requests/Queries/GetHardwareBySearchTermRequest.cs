using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Requests.Queries
{
    public class GetHardwareBySearchTermRequest : IRequest<List<HardwareDto>>
    {
        public string SearchTerm { get; set; }
    }
}
