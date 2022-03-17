using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Handlers.Queries
{
    public class GetAllVendorsRequestHandler : GenericGetAllRequestHandler<IVendorRepository, VendorDto, Vendor>
    {
        public GetAllVendorsRequestHandler(IVendorRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
