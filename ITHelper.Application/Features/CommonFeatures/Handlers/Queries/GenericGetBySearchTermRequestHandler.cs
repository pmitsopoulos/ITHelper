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
    public class GenericGetBySearchTermRequestHandler
        <TRepository, TEntityDto, TDomainEntity>
        : IRequestHandler<GenericGetBySearchTermRequest<TEntityDto>, List<TEntityDto>>
        where TRepository : IGenericRepository<TDomainEntity>
        where TDomainEntity : class
    {
        private readonly TRepository repository;
        private readonly IMapper mapper;

        public GenericGetBySearchTermRequestHandler(TRepository repository, IMapper mapper )
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<TEntityDto>> Handle(GenericGetBySearchTermRequest<TEntityDto> request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAllAsync();

            if (result == null)
            {
                throw new NotFoundException(nameof(TDomainEntity), "Nothing was found");
            }
            return mapper.Map<List<TEntityDto>>(result);
        }
    }
}
