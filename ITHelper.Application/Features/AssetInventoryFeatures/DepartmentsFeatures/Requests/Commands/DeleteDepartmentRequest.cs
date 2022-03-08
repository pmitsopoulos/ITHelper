using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Requests.Commands
{
    public class DeleteDepartmentRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
