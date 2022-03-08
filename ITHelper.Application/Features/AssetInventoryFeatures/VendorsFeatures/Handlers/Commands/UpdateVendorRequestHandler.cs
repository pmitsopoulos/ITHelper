using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs.Validators;
using ITHelper.Application.Exceptions;
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
    public class UpdateVendorRequestHandler : IRequestHandler<UpdateVendorRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateVendorRequestHandler(IUnitOfWork unitOfWork
            ,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateVendorRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if(!(await unitOfWork.VendorRepository.Exists(request.VendorDto.Id)))
            {
                response.Message = "The Vendor was not found and cannot be updated";
                response.Errors.Add(new NotFoundException(nameof(Vendor), request.VendorDto.Id).Message);
                response.Success = false;
            }
            else
            {
                var validator = new UpdateVendorDtoValidator(unitOfWork.VendorRepository);

                var validationResult = await validator.ValidateAsync(request.VendorDto);

                if(!validationResult.IsValid)
                {
                    response.Message = "The Vendor is not valid";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    response.Success = false;
                }
                else
                {
                    var vendorTBU = await unitOfWork.VendorRepository.GetByIdAsync(request.VendorDto.Id);

                    mapper.Map(request.VendorDto, vendorTBU);

                    await unitOfWork.VendorRepository.UpdateAsync(vendorTBU);
                    await unitOfWork.Save();

                    response.Success = true;
                    response.Message = "Vendor was updated successfully";
                    response.Id = vendorTBU.Id;
                }
            }

            return response;
        }
    }
}
