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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Primary key ayarlamalari
            builder.HasKey(x => x.Id);

            // 1er 1er primary key artsin.
            builder.Property(t => t.Id).UseIdentityColumn();

            builder.Property(x => x.Content).IsRequired().HasMaxLength(50);
        }
    }
}
