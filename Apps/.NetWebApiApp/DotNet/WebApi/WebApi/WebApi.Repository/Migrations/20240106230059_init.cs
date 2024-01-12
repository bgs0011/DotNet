using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArticleContent = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Like = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "PublisherName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4611), "AlbertCamus@gmail.com", "539365", "Albert Camus", null },
                    { 2, new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4613), "LeonardoDaVinci@gmail.com", "059718", "Leonardo da Vinci", null },
                    { 3, new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4614), "ImmanuelKant@gmail.com", "119641", "Immanuel Kant", null },
                    { 4, new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4615), "AlbertEinstein@gmail.com", "994643", "Albert Einstein", null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleContent", "CreatedDate", "PublisherId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "“Man stands face to face with the irrational. He feels within him his longing for happiness and for reason. The absurd is born of this confrontation between the human need and the unreasonable silence of the world.”", new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4233), 1, "The Myth of Sisyphus and Other Essays", null },
                    { 2, "I am enough of an artist to draw freely upon my imagination. Imagination is more important than knowledge. Knowledge is limited. Imagination encircles the world.", new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4248), 4, "What Life Means to Einstein", null },
                    { 3, "Dare to think!", new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4250), 3, "What is Enlightenment?", null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "Content", "CreatedDate", "UpdatedDate" },
                values: new object[] { 1, 3, "I Dare!", new DateTime(2024, 1, 7, 2, 0, 59, 230, DateTimeKind.Local).AddTicks(4490), null });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PublisherId",
                table: "Articles",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
