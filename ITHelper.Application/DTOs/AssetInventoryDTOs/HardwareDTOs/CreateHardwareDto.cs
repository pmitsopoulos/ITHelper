using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs
{
    public class CreateHardwareDto
    {
        public CreateHardwareDto()
        {
            InitializationDate = DateTime.Now;
            IsAssigned = false;
            IsOperational = true;
        }
        public int VendorId { get; set; }
        public int HardwareTypeId { get; set; }
        public string Model { get; set; }
        public bool IsOperational { get; set; }
        public string SerialNumber { get; set; }
        public DateTime InitializationDate { get; set; }
        public int HardwareSpecificationId { get; set; }
        public int ContactId { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public bool IsAssigned { get; set; }

    }
}
