using AutoMapper;
using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.CommonFeatures.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.CommonFeatures.Handlers.Queries
{
    public class GenericGetByIdRequestHandler
        <TRepository, TEntityDto, TDomainEntity>
        : IRequestHandler<GenericGetByIdRequest<TEntityDto>, TEntityDto>
        where TRepository : IGenericRepository<TDomainEntity>
        where TDomainEntity : class
    {
        private readonly TRepository repository;
        private readonly IMapper mapper;

        public GenericGetByIdRequestHandler(TRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<TEntityDto> Handle(GenericGetByIdRequest<TEntityDto> request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.Id);

            if(result == null)
            {
                throw new NotFoundException(nameof(TDomainEntity), request.Id);
            }    
            return mapper.Map<TEntityDto>(result);
        }
    }
}
