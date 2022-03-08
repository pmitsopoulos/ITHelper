using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Requests.Queries
{
    public class GetHardwareTypesBySearchTermRequest : IRequest<List<HardwareTypeDto>>
    {
        public string SearchTerm { get; set; }
    }
}
