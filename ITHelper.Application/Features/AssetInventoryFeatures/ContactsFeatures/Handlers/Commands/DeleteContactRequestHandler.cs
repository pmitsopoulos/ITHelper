using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
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
    public class DeleteContactRequestHandler : IRequestHandler<DeleteContactRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteContactRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (!(await unitOfWork.ContactRepository.Exists(request.Id)))
            {
                response.Message = "The specified Contact does not exist";
                response.Errors.Add(new NotFoundException(nameof(Contact), request.Id).Message);
                response.Success = false;
            }
            else
            {
                await unitOfWork.ContactRepository.DeleteAsync(request.Id);
                await unitOfWork.Save();

                response.Success = true;
                response.Message = "The Contact was deleted successfully";
            }
            return response;
        }
    }
}
