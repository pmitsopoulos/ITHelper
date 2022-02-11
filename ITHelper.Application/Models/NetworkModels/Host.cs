using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Models.NetworkModels
{
    public class Host
    { 
        public string IPAddress { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
