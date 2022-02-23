using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs
{
    public class CreateDepartmentDto : IDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
