using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs.Validators;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Handlers.Commands
{
    public class UpdateContactRequestHandler : IRequestHandler<UpdateContactRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateContactRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateContactRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var validator = new UpdateContactDtoValidator(unitOfWork.ContactRepository);

            var validationResult = await validator.ValidateAsync(request.ContactDto);

            if(validationResult.IsValid)
            {
                if(!(await unitOfWork.ContactRepository.Exists(request.ContactDto.Id)))
                {
                    response.Message = "The specified Contact does not exist";
                    response.Success = false;
                    response.Errors.Add(new NotFoundException(nameof(Contact), request.ContactDto.Id).Message);
                }
                else
                {
                    var contactTBU = await unitOfWork.ContactRepository.GetByIdAsync(request.ContactDto.Id);
                
                    mapper.Map(request.ContactDto,contactTBU);

                    await unitOfWork.ContactRepository.UpdateAsync(contactTBU);

                    await unitOfWork.Save();

                    response.Message = "Contact updated successfully.";
                    response.Success = true;
                    response.Id = contactTBU.Id;

                }
            }
            else
            {
                response.Message = "Contact is invalid";
                response.Errors = validationResult.Errors.Select(x=>x.ErrorMessage).ToList();
                response.Success = false;
            }

            return response;
        }
    }
}
