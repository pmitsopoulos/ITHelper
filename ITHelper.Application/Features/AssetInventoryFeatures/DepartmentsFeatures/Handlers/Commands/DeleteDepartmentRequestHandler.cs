using AutoMapper;
using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Handlers.Commands
{
    public class DeleteDepartmentRequestHandler
        : GenericDeleteRequestHandler<IUnitOfWork, IDepartmentRepository, Department>
    {
        public DeleteDepartmentRequestHandler(IUnitOfWork genericUnitOfWork, IMapper mapper, IDepartmentRepository repository)
            : base(genericUnitOfWork, mapper, repository)
        {
        }
    }

}
