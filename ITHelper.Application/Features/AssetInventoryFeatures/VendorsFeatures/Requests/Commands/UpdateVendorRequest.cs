using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Requests.Commands
{
    public class UpdateVendorRequest : IRequest<BaseResponse>
    {
        public UpdateVendorDto VendorDto { get; set; }
    }
}
