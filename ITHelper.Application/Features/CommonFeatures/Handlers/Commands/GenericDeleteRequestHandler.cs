using AutoMapper;
using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
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
    public class GenericDeleteRequestHandler<TUnitOfWork, TRepository, TDomainEntity>
        : IRequestHandler<GenericDeleteRequest<TDomainEntity>, BaseResponse>
        where TUnitOfWork : IGenericUnitOfWork
        where TRepository : IGenericRepository<TDomainEntity>
        where TDomainEntity : class
    {
        private readonly TUnitOfWork genericUnitOfWork;
        private readonly TRepository repository;

        public GenericDeleteRequestHandler(TUnitOfWork genericUnitOfWork, IMapper mapper,TRepository repository)
        {
            this.genericUnitOfWork = genericUnitOfWork;
            this.repository = repository;
        }


        public async Task<BaseResponse> Handle(GenericDeleteRequest<TDomainEntity> request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var entityExists = await repository.Exists(request.Id);
            var res = await repository.GetByIdAsync(request.Id);

            if (entityExists != true)
            {
                response.Message = $"This {typeof(TDomainEntity).Name} does not exist";
                response.Success = false;
            }
            else
            {
                await repository.DeleteAsync(request.Id);
                await genericUnitOfWork.Save();

                response.Success = true;
                response.Message = $"{typeof(TDomainEntity).Name} was deleted successfully";
            }

            return response;
        }
    }
}
