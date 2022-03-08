using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Requests.Commands
{
    public class CreateDepartmentRequest : IRequest<BaseResponse>
    {
        public CreateDepartmentDto DepartmentDto { get; set; }
    }
}
