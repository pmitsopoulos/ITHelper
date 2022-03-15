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
                    Name = "Dell"
                },
                new Vendor
                {
                    Id = 2,
                    Name = "HP"
                },
                new Vendor
                {
                    Id = 3,
                    Name = "Lenovo"
                },
                new Vendor
                {
                    Id = 4,
                    Name = "Apple"
                },
                new Vendor
                {
                    Id = 5,
                    Name = "Samsung"
                },
                new Vendor
                {
                    Id = 6,
                    Name = "Xiaomi"
                },
                new Vendor
                {
                    Id = 7,
                    Name = "Asus"
                },
                new Vendor
                {
                    Id = 8,
                    Name = "Ricoh"
                }
                );
        }
    }
}
