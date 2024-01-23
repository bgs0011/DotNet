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
    public class ImageSeed : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
                new Image
                {
                    Id = 1,
                    FileName = "image test",
                    FileType = "type test",

                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin",
                    isDeleted = false
                },
                new Image
                {
                    Id = 2,
                    FileName = "image test2",
                    FileType = "type test2",

                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin",
                    isDeleted = false
                }
                );
        }
    }
}
