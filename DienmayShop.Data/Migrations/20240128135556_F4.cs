using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DienmayShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class F4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsShowHome = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SeoTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LanguageId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    SeoAlias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c980b911-edd8-4216-b56b-815f53bd0fd1", "AQAAAAIAAYagAAAAEJ9Uhb/xZYWPsEU5ACuiD1xnqWNS7BcC70fJ4eLbdh+njQA7VfSmY3i2UoeJt1gtOQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86c2cb55-97a9-4b88-8daf-ebbf3696f179", "AQAAAAIAAYagAAAAEASIwE+izU7UkxCLiXBqAQRGPAHVtETksz66Ey/T7P4D1zjqZK01dn7TtbJdbTPGgA==" });
        }
    }
}
