using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DienmayShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class F6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b17e72e-f683-465f-a345-bd851339b486", "AQAAAAIAAYagAAAAEJuRmMhVtXMSRwLQ+0UbxJqAq3cWnBuuaxb4dVT3bQM28pHKtzZh+1T7K87Fmt4OTQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 5, 13, 20, 30, 460, DateTimeKind.Local).AddTicks(4660));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bff81b38-928f-4a23-9931-9b2fc2ffca9b", "AQAAAAIAAYagAAAAEJRpnJx1dKOYoUWQrRu5fwtwVziVg4tIBA8B9AKjOCQjg+26idf/m3a8JqKq+qP4Dg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 1, 28, 21, 36, 27, 962, DateTimeKind.Local).AddTicks(1642));
        }
    }
}
