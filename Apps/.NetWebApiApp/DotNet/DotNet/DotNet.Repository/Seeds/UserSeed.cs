using DotNet.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Repository.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Email = "AlbertCamus@gmail.com", Password = "539365", UserName = "Albert Camus", CreatedDate = DateTime.Now },
                new User { Id = 2, Email = "LeonardoDaVinci@gmail.com", Password = "059718", UserName = "Leonardo da Vinci", CreatedDate = DateTime.Now },
                new User { Id = 3, Email = "ImmanuelKant@gmail.com", Password = "119641", UserName = "Immanuel Kant", CreatedDate = DateTime.Now },
                new User { Id = 4, Email = "AlbertEinstein@gmail.com", Password = "994643", UserName = "Albert Einstein", CreatedDate = DateTime.Now }
                );
        }
    }
}
