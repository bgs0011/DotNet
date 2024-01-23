using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;

namespace WebApp.Repository.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> b)
        {
            var superadmin = new AppUser
            {
                Id = 1,
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.com",
                PhoneNumber = "+9054399999999",
                FirstName = "Buse",
                LastName = "Sezer",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                ImageId = 1,
                SecurityStamp = Guid.NewGuid().ToString()

            };
            superadmin.PasswordHash = CreatePasswordHash(superadmin, "123456");

            var admin = new AppUser
            {
                Id = 2,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.com",
                PhoneNumber = "+9054399999988",
                FirstName = "Admin",
                LastName = "User",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                ImageId= 2,
                SecurityStamp = Guid.NewGuid().ToString()

            };
            admin.PasswordHash = CreatePasswordHash(admin, "123456");

            b.HasData(superadmin, admin);
        }
        private string CreatePasswordHash(AppUser appUser, string password)
        {
            var passworHash = new PasswordHasher<AppUser>();
            return passworHash.HashPassword(appUser, password);
        }
    }
}
