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
    public class UserRoleSeed : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> b)
        {
            b.HasData(
               new AppUserRole
               {
                   RoleId = 1,
                   UserId = 1,
               },
               new AppUserRole
               {
                   RoleId = 2,
                   UserId = 2,
               }
               );
        }
    }
}
