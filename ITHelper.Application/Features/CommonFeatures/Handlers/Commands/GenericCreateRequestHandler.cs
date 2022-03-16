using AutoMapper;
using FluentValidation;
using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
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
    public class GenericCreateRequestHandler<TUnitOfWork, 
        TEntityDto, TDomainEntity, TRepository, TValidator>
        : IRequestHandler<GenericCreateRequest<TEntityDto>, BaseResponse>
        where TValidator : IValidator<TEntityDto>
        where TRepository : IGenericRepository<TDomainEntity>
        where TUnitOfWork : IGenericUnitOfWork 
        where TDomainEntity : class
       
        
     {
        private readonly TUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly TRepository repository;
        private readonly TValidator validator;

        public GenericCreateRequestHandler(TUnitOfWork unitOfWork, IMapper mapper
            , TRepository repository, TValidator validator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<BaseResponse> Handle(GenericCreateRequest<TEntityDto> request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var validationResult = await validator.ValidateAsync(request.EntityTBC);

            if(!validationResult.IsValid)
            {
                response.Message = $"{typeof(TDomainEntity).Name} creation failed.";
                response.Success = false;
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var entityTBC = mapper.Map<TDomainEntity>(request.EntityTBC);

                await repository.CreateAsync(entityTBC);
                await unitOfWork.Save();

                response.Message = $"{typeof(TDomainEntity).Name} creation was successful";
                response.Success = true;
            }

            return response;

            
        }
    }
}
