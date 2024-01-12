﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Repository;

#nullable disable

namespace WebApi.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Core.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArticleContent")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Like")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleContent = "“Man stands face to face with the irrational. He feels within him his longing for happiness and for reason. The absurd is born of this confrontation between the human need and the unreasonable silence of the world.”",
                            CreatedDate = new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4233),
                            Like = 0,
                            PublisherId = 1,
                            Title = "The Myth of Sisyphus and Other Essays"
                        },
                        new
                        {
                            Id = 2,
                            ArticleContent = "I am enough of an artist to draw freely upon my imagination. Imagination is more important than knowledge. Knowledge is limited. Imagination encircles the world.",
                            CreatedDate = new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4248),
                            Like = 0,
                            PublisherId = 4,
                            Title = "What Life Means to Einstein"
                        },
                        new
                        {
                            Id = 3,
                            ArticleContent = "Dare to think!",
                            CreatedDate = new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4250),
                            Like = 0,
                            PublisherId = 3,
                            Title = "What is Enlightenment?"
                        });
                });

            modelBuilder.Entity("WebApi.Core.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 3,
                            Content = "I Dare!",
                            CreatedDate = new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4490)
                        });
                });

            modelBuilder.Entity("WebApi.Core.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4611),
                            Email = "AlbertCamus@gmail.com",
                            Password = "539365",
                            PublisherName = "Albert Camus"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4613),
                            Email = "LeonardoDaVinci@gmail.com",
                            Password = "059718",
                            PublisherName = "Leonardo da Vinci"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4614),
                            Email = "ImmanuelKant@gmail.com",
                            Password = "119641",
                            PublisherName = "Immanuel Kant"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4615),
                            Email = "AlbertEinstein@gmail.com",
                            Password = "994643",
                            PublisherName = "Albert Einstein"
                        });
                });

            modelBuilder.Entity("WebApi.Core.Models.Article", b =>
                {
                    b.HasOne("WebApi.Core.Models.Publisher", "Publisher")
                        .WithMany("Article")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("WebApi.Core.Models.Comment", b =>
                {
                    b.HasOne("WebApi.Core.Models.Article", "Article")
                        .WithMany("Comment")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("WebApi.Core.Models.Article", b =>
                {
                    b.Navigation("Comment");
                });

            modelBuilder.Entity("WebApi.Core.Models.Publisher", b =>
                {
                    b.Navigation("Article");
                });
#pragma warning restore 612, 618
        }
    }
}
