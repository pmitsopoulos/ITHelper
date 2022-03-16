using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.NetworkPortInfoEntities
{
    public class NetworkPortInformation : BaseDomainEntity
    {
        [Required]
        public string PortNumber { get; set; }
        [Required]
        public string Protocol { get; set; }
        [Required]
        public string UseDescription { get; set; }
        public string Comments { get; set; }
    }
}
