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
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            // Primary key ayarlamalari
            builder.HasKey(x => x.Id);

            // 1er 1er primary key artsin.
            builder.Property(t => t.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

            builder.Property(x => x.ArticleContent).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.Like).HasDefaultValue(0);
        }
    }
}
