using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DienmayShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class F1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhungTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", unicode: false, maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhungTests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PhungTests",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "test thoi ma." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhungTests");
        }
    }
}
