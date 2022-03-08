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
    public class GetVendorRequestHandler : IRequestHandler<GetVendorRequest, VendorDto>
    {
        private readonly IVendorRepository vendorRepository;
        private readonly IMapper mapper;

        public GetVendorRequestHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            this.vendorRepository = vendorRepository;
            this.mapper = mapper;
        }
        public async Task<VendorDto> Handle(GetVendorRequest request, CancellationToken cancellationToken)
        {
            var vendor = await vendorRepository.GetByIdAsync(request.Id);

            if(vendor == null)
            {
                throw new NotFoundException(nameof(Vendor), request.Id);
            }

            return mapper.Map<VendorDto>(vendor);
        }
    }
}
