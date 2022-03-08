using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using MediatR;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Requests.Queries
{
    public class GetDepartmentRequest : IRequest<DepartmentDto>
    {
        public int Id { get; set; }

    }
}
