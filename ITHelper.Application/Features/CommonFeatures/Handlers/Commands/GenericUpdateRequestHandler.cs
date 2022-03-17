using AutoMapper;
using FluentValidation;
using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.DTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.CommonFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.CommonFeatures.Handlers.Commands
{
    public class GenericUpdateRequestHandler
        <TUnitOfWork, TRepository, TEntityDto, TDomainEntity, TValidator>
        : IRequestHandler<GenericUpdateRequest<TEntityDto>, BaseResponse>
            where TUnitOfWork : IGenericUnitOfWork
            where TRepository : IGenericRepository<TDomainEntity>
            where TValidator : IValidator<TEntityDto>
            where TDomainEntity : class
            where TEntityDto : BaseDto
    {
        private readonly TUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly TRepository repository;
        private readonly TValidator validator;

        public GenericUpdateRequestHandler(TUnitOfWork unitOfWork,IMapper mapper,
           TRepository repository, TValidator validator)

        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<BaseResponse> Handle(GenericUpdateRequest<TEntityDto> request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            

            var entityExists = await repository.Exists(request.EntityTBU.Id);

            if(entityExists != true)
            {
                response.Message = $"The specified {typeof(TDomainEntity).Name} does not exist";
                response.Success = false;
            }
            else
            {
                var validationResult = await validator.ValidateAsync(request.EntityTBU);

                if(validationResult.IsValid != true)
                {
                    response.Message = $"{typeof(TDomainEntity).Name} is invalid";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    response.Success = false;
                }
                else
                {
                    var entityTBU =await repository.GetByIdAsync(request.EntityTBU.Id);

                    mapper.Map(request.EntityTBU, entityTBU);

                    await repository.UpdateAsync(entityTBU);
                    await unitOfWork.Save();

                    response.Message = $"{typeof(TDomainEntity).Name} updated successfully.";
                    response.Success = true;
                    response.Id = request.EntityTBU.Id;
                }
            }
            return response;
        }
    }
}
