using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechPulse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "PublishedAt", "Title" },
                values: new object[,]
                {
                    { 1, "AI", "OpenAI's latest model sets new records in reasoning and coding tasks.", null, new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "GPT-5 Redefines Language Model Benchmarks" },
                    { 2, "WebDevelopment", "The new signals-based approach eliminates the need for NgRx in most apps.", null, new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular 19 Signals API Changes State Management" },
                    { 3, "Security", "Security researchers disclosed a widespread flaw affecting cloud instances.", null, new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Critical Zero-Day Vulnerability Patched in Cloud Providers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
