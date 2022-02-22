﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Domain.AssetInventoryEntities
{
    
    public class HardwareSpecification : BaseDomainEntity
    {
        public string CPU { get; set; }
        public int QuantityOfRAM { get; set; }
        public string TypeOfRAM { get; set; }
        public bool SSDTypeOfHDD { get; set; }
        public int QuantityOfROM { get; set; }
        public string OS { get; set; }

        public virtual Hardware Hardware { get; set; }
    }
}
