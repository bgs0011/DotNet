using DotNet.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary key ayarlamalari
            builder.HasKey(x => x.Id);

            // 1er 1er primary key artsin.
            builder.Property(t => t.Id).UseIdentityColumn();

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);

            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);

        }
    }
}
