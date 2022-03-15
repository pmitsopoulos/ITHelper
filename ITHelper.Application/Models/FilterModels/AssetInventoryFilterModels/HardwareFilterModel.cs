using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Models.FilterModels.AssetInventoryFilterModels
{
    public class HardwareFilterModel
    {
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public int HardwareTypeId { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsOperational { get; set; }
    }
}
