using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yol.Data.Migrations
{
    public partial class FixedApplicationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("02a022d9-0638-4502-a7f9-48869f5e300e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("36c0b402-098b-4749-b8bb-874b82311f12"));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("70b18d89-1f7f-4882-9b04-a815906db3e8"), "c72e364c-a9cb-46ab-80b2-2ed75efa8b10", "Admin", "ADMIN" },
                    { new Guid("5669c04b-06e9-4e48-9c03-7436fe48ca42"), "e6524b0c-e5b9-47f0-b7c3-8672c75e17dc", "SuperAdmin", "SUPERADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5669c04b-06e9-4e48-9c03-7436fe48ca42"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70b18d89-1f7f-4882-9b04-a815906db3e8"));

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Applications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("36c0b402-098b-4749-b8bb-874b82311f12"), "37ed9641-3425-4261-aa3a-08eb30d825b4", "Admin", "ADMIN" },
                    { new Guid("02a022d9-0638-4502-a7f9-48869f5e300e"), "0cb39786-57a1-45cd-b94c-077e09856637", "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
