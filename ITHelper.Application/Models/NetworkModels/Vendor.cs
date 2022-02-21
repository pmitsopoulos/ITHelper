using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Models.NetworkModels
{
    /// <summary>
    /// This Entity has the purpose of representing
    /// the results of the MAC Vendor API
    /// </summary>
    public class Vendor
    {
        public string Name { get; set; }

        [Display(Name="MAC Address")]
        public string PhysicalAddress { get; set; }
    }
}
