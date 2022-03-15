using ITHelper.Domain.AssetInventoryEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Configurations.AssetInventoryConfigurations
{
    public class HardwareTypeConfiguration : IEntityTypeConfiguration<HardwareType>
    {
        public void Configure(EntityTypeBuilder<HardwareType> builder)
        {
            builder.HasData(
                new HardwareType
                {
                    Id = 1,
                    Name = "Desktop Computer / Workstation",
                    Description = "Desktop Computers are considered all non-portable Computers"
                },
                new HardwareType
                {
                    Id = 2,
                    Name = "Laptop Computer",
                    Description = "Laptop Computers are considered all the portable Computers"
                },
                new HardwareType
                {
                    Id = 3,
                    Name = "Smartphone / Phone",
                },
                new HardwareType
                {
                    Id = 4,
                    Name = "Tablet"
                },
                new HardwareType
                {
                    Id = 5,
                    Name = "Printer / Multifunctional",
                }
                );
        }
    }
}
