using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs
{
    public class UpdateSiteDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
