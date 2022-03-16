using ITHelper.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Identity.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    Fullname = "System Admin",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "admin"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
