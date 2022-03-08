using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs.Validators;
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
    public class CreateContactRequestHandler : IRequestHandler<CreateContactRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateContactRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse> Handle(CreateContactRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var validator = new CreateContactDtoValidator(unitOfWork.ContactRepository);

            var validationResult = await validator.ValidateAsync(request.ContactDto);

            if (!validationResult.IsValid)
            {
                response.Message = "Contact creation request failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                response.Success = false;
            }
            else
            {
                var contactTBC = mapper.Map<Contact>(request.ContactDto);

                await unitOfWork.ContactRepository.CreateAsync(contactTBC);
                await unitOfWork.Save();

                response.Message = "Contact created Successfully";
                response.Success = true;
            }

            return response;
        }
    }
}
