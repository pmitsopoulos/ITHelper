using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Handlers.Commands
{
    public class UpdateDepartmentRequestHandler
        : GenericUpdateRequestHandler<IUnitOfWork, IDepartmentRepository, UpdateDepartmentDto, Department, UpdateDepartmentDtoValidator>
    {
        public UpdateDepartmentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, 
            IDepartmentRepository repository, UpdateDepartmentDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
