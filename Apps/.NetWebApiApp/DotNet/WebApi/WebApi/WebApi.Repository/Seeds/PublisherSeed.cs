using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;

namespace WebApi.Repository.Seeds
{
    public class PublisherSeed : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(
                new Publisher { Id = 1, Email = "AlbertCamus@gmail.com", Password = "539365", PublisherName = "Albert Camus", CreatedDate = DateTime.Now },
                new Publisher { Id = 2, Email = "LeonardoDaVinci@gmail.com", Password = "059718", PublisherName = "Leonardo da Vinci", CreatedDate = DateTime.Now },
                new Publisher { Id = 3, Email = "ImmanuelKant@gmail.com", Password = "119641", PublisherName = "Immanuel Kant", CreatedDate = DateTime.Now },
                new Publisher { Id = 4, Email = "AlbertEinstein@gmail.com", Password = "994643", PublisherName = "Albert Einstein", CreatedDate = DateTime.Now }
                );
        }
    }
}
