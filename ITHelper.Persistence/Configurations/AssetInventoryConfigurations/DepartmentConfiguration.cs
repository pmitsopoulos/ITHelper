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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = 1,
                    Name = "Management"
                },
                new Department
                {
                    Id = 2,
                    Name = "Accounting"
                },
                new Department
                {
                    Id = 3,
                    Name = "ITC"
                },
                new Department
                {
                    Id = 4,
                    Name = "Administration"
                }
                );
        }
    }
}
