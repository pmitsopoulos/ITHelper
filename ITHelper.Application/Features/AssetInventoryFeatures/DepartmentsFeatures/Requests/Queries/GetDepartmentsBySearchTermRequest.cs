
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Requests.Queries
{
    public class GetDepartmentsBySearchTermRequest : IRequest<List<DepartmentDto>>
    {
        public string SearchTerm { get; set; }
    }
}
