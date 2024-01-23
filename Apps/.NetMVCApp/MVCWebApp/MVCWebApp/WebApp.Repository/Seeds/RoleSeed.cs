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
    public class RoleSeed : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> b)
        {
            // Create new Role
            b.HasData(new AppRole
            {
                Id = 1,
                Name = "Superadmin",
                NormalizedName = "SUPERADMIN",
            });

            b.HasData(new AppRole
            {
                Id = 2,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            b.HasData(new AppRole
            {
                Id = 3,
                Name = "User",
                NormalizedName = "USER"
            });
        }
    }
}
