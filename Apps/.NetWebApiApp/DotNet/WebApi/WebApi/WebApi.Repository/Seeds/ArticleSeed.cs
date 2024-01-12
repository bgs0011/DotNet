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
    public class ArticleSeed : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(
                new Article
                {
                    Id = 1,
                    ArticleContent = "“Man stands face to face with the irrational. He feels within him his longing for happiness and for reason. The absurd is born of this confrontation between the human need and the unreasonable silence of the world.”"
                ,
                    CreatedDate = DateTime.Now,
                    Title = "The Myth of Sisyphus and Other Essays",
                    PublisherId = 1
                },
                new Article
                {
                    Id = 2,
                    ArticleContent = "I am enough of an artist to draw freely upon my imagination. Imagination is more important than knowledge. Knowledge is limited. Imagination encircles the world."
                ,
                    CreatedDate = DateTime.Now,
                    Title = "What Life Means to Einstein",
                    PublisherId = 4
                },
                new Article
                {
                    Id = 3,
                    ArticleContent = "Dare to think!"
                ,
                    CreatedDate = DateTime.Now,
                    Title = "What is Enlightenment?",
                    PublisherId = 3
                }
                );
        }
    }
}
