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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Test",

                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin",
                    isDeleted = false

                },
                new Category
                {
                    Id = 2,
                    Name = "Test2",

                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin",
                    isDeleted = false

                }
                );
        }
    }
}
