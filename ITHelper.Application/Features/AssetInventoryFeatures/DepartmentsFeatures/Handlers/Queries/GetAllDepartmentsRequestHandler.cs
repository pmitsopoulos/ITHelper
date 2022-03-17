using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Handlers.Queries
{
    public class GetAllDepartmentsRequestHandler : GenericGetAllRequestHandler<IDepartmentRepository, DepartmentDto, Department>
    {
        public GetAllDepartmentsRequestHandler(IDepartmentRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
