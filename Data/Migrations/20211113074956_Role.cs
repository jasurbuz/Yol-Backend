using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yol.Data.Migrations
{
    public partial class Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("36c0b402-098b-4749-b8bb-874b82311f12"), "37ed9641-3425-4261-aa3a-08eb30d825b4", "Admin", "ADMIN" },
                    { new Guid("02a022d9-0638-4502-a7f9-48869f5e300e"), "0cb39786-57a1-45cd-b94c-077e09856637", "SuperAdmin", "SUPERADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("02a022d9-0638-4502-a7f9-48869f5e300e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("36c0b402-098b-4749-b8bb-874b82311f12"));
        }
    }
}
