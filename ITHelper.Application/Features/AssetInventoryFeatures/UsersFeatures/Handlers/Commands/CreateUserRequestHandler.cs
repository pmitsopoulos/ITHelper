using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs.Validators;
using ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Handlers.Commands
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var validator = new CreateUserDtoValidator(unitOfWork.UserRepository);

            var validationResult = await validator.ValidateAsync(request.UserDto);
            
            if (!validationResult.IsValid)
            {
                response.Message = "User creation request failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                response.Success = false;
            }
            else
            {
                var departmentTBC = mapper.Map<User>(request.UserDto);

                await unitOfWork.UserRepository.CreateAsync(departmentTBC);
                await unitOfWork.Save();

                response.Message = "User was created successfully.";
                response.Success = true;
            }
            return response;
        }
    }
}
