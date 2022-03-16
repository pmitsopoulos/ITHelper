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
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasData(
                new Vendor
                {
                    Id = 1,
                    Name = "Dell",
                    Description = string.Empty
                },
                new Vendor
                {
                    Id = 2,
                    Name = "HP",
                    Description = string.Empty
                },
                new Vendor
                {
                    Id = 3,
                    Name = "Lenovo",
                    Description = string.Empty
                },
                new Vendor
                {
                    Id = 4,
                    Name = "Apple",
                    Description = string.Empty
                },
                new Vendor
                {
                    Id = 5,
                    Name = "Samsung",
                    Description = string.Empty
                },
                new Vendor
                {
                    Id = 6,
                    Name = "Xiaomi",
                    Description = string.Empty
                },
                new Vendor
                {
                    Id = 7,
                    Name = "Asus",
                    Description = string.Empty
                },
                new Vendor
                {
                    Id = 8,
                    Name = "Ricoh",
                    Description = string.Empty
                }
                );
        }
    }
}
