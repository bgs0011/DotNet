using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Linq;

namespace WebApp.Repository.Seeds
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
                    Title = "The Myth of Sisyphus and Other Essays",
                    ViewCount= 666,

                    CategoryId=1,
                    ImageId=1,
                    UserId=1,

                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin",
                    isDeleted = false,

                    Image = {
                        Id = 1,
                        FileName = "image test",
                        FileType = "type test",

                        CreatedDate = DateTime.Now,
                        CreatedBy = "Admin",
                        isDeleted = false
                    },

                    Category = {
                        Id = 1,
                        Name = "Test",

                        CreatedDate = DateTime.Now,
                        CreatedBy = "Admin",
                        isDeleted = false

                    }


                },
                new Article
                {
                    Id = 2,
                    ArticleContent = "I am enough of an artist to draw freely upon my imagination. Imagination is more important than knowledge. Knowledge is limited. Imagination encircles the world."
                ,
                    Title = "What Life Means to Einstein",

                    CategoryId = 1,
                    ImageId = 2,
                    UserId=2,

                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin",
                    isDeleted = false,

                    Category = {
                        Id = 1,
                        Name = "Test",

                        CreatedDate = DateTime.Now,
                        CreatedBy = "Admin",
                        isDeleted = false

                    },
                    Image = {
                        Id = 2,
                        FileName = "image test2",
                        FileType = "type test2",

                        CreatedDate = DateTime.Now,
                        CreatedBy = "Admin",
                        isDeleted = false
                    }
                },
                new Article
                {
                    Id = 3,
                    ArticleContent = "Dare to think!"
                ,
                    Title = "What is Enlightenment?",

                    CategoryId = 2,
                    ImageId = 1,
                    UserId=2,

                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin",
                    isDeleted = false,

                    Category ={
                        Id = 2,
                        Name = "Test2",

                        CreatedDate = DateTime.Now,
                        CreatedBy = "Admin",
                        isDeleted = false

                    },
                    Image ={
                        Id = 1,
                        FileName = "image test",
                        FileType = "type test",

                        CreatedDate = DateTime.Now,
                        CreatedBy = "Admin",
                        isDeleted = false
                    }
                }
                );
        }
    }
}
