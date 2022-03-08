using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Requests.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Handlers.Queries
{
    public class GetVendorBySearchTermRequestHandler
        : IRequestHandler<GetVendorBySearchTermRequest, List<VendorDto>>
    {
        private readonly IVendorRepository vendorRepository;
        private readonly IMapper mapper;

        public GetVendorBySearchTermRequestHandler(IVendorRepository vendorRepository
            ,IMapper mapper)
        {
            this.vendorRepository = vendorRepository;
            this.mapper = mapper;
        }
        public async Task<List<VendorDto>> Handle(GetVendorBySearchTermRequest request, CancellationToken cancellationToken)
        {
            var vendors = await vendorRepository.GetBySearchTermAsync(request.SearchTerm);

            if(vendors == null)
            {
                throw new NotFoundException(nameof(Vendor), request.SearchTerm);
            }
            return mapper.Map<List<VendorDto>>(vendors);
        }
    }
}
