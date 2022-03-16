using ITHelper.Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Identity.Services
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("Default"),
                    new MySqlServerVersion(new Version(8, 0, 26)));
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "";
                options.AccessDeniedPath = "";
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
                
            })
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero,
            //            ValidIssuer = configuration["JwtSettings:Issuer"],
            //            ValidAudience = configuration["JwtSettings:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            //        };
            //    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireClaim("Admin");
                });
            });

            return services;
        }
    }
}
