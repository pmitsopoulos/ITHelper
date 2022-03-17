using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Handlers.Queries
{
    public class GetDepartmentsBySearchTermRequestHandler
        : GenericGetBySearchTermRequestHandler<IDepartmentRepository, DepartmentDto, Department>
    {
        public GetDepartmentsBySearchTermRequestHandler(IDepartmentRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
