using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Requests.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Handlers.Queries
{
    public class GetDepartmentsBySearchTermRequestHandler : IRequestHandler<GetDepartmentsBySearchTermRequest, List<DepartmentDto>>
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public GetDepartmentsBySearchTermRequestHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }
        public async Task<List<DepartmentDto>> Handle(GetDepartmentsBySearchTermRequest request, CancellationToken cancellationToken)
        {
            var departments = await departmentRepository.GetBySearchTermAsync(request.SearchTerm);

            if(departments == null)
            {
                throw new NotFoundException(nameof(Department), request.SearchTerm);
            }
            
            return mapper.Map<List<DepartmentDto>>(departments);
        }
    }
}
