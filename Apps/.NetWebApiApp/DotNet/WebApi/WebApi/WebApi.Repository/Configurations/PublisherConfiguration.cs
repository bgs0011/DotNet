using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;

namespace WebApi.Repository.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            // Primary key ayarlamalari
            builder.HasKey(x => x.Id);

            // 1er 1er primary key artsin.
            builder.Property(t => t.Id).UseIdentityColumn();

            builder.Property(x => x.PublisherName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);

            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);

        }
    }
}
