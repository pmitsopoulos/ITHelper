using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs.Validators;
using ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Handlers.Commands
{
    public class CreateVendorRequestHandler : IRequestHandler<CreateVendorRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateVendorRequestHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateVendorRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var validator = new CreateVendorDtoValidator(unitOfWork.VendorRepository);

            var validationResult = await validator.ValidateAsync(request.VendorDto);

            if(!validationResult.IsValid)
            {
                response.Message = "Vendor is not valid.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                response.Success = false;
            }
            else
            {
                var vendorTBC = mapper.Map<Vendor>(request.VendorDto);

                await unitOfWork.VendorRepository.CreateAsync(vendorTBC);
                await unitOfWork.Save();

                response.Message = "Vendor was created successfully.";
                response.Success = true;
            }
            return response;
        }
    }
}
