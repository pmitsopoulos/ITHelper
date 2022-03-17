using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.Models.FilterModels.AssetInventoryFilterModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Requests.Queries
{
    public class GetHardwareByFilteredSearchRequest : IRequest<List<HardwareDto>>
    {
        public HardwareFilterModel HardwareFilter { get; set; }
    }
}
