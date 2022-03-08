﻿using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Requests.Queries
{
    public class GetVendorBySearchTermRequest : IRequest<List<VendorDto>>
    {
        public string SearchTerm { get; set; }
    }
}
