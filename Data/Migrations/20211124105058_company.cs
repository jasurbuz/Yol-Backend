using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yol.Data.Migrations
{
    public partial class company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "DateOfFoundation",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d1e7d1f-2c41-43b4-a8e1-4b4aa2b57908"), "37643355-457f-4ab5-ae22-fac9cd548526", "Admin", "ADMIN" },
                    { new Guid("7b921da4-35d1-4c14-b368-cebd096ad4ff"), "a16e5aa8-4d08-4326-b853-fb9227888859", "SuperAdmin", "SUPERADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b921da4-35d1-4c14-b368-cebd096ad4ff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d1e7d1f-2c41-43b4-a8e1-4b4aa2b57908"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfFoundation",
                table: "Companies",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("70b18d89-1f7f-4882-9b04-a815906db3e8"), "c72e364c-a9cb-46ab-80b2-2ed75efa8b10", "Admin", "ADMIN" },
                    { new Guid("5669c04b-06e9-4e48-9c03-7436fe48ca42"), "e6524b0c-e5b9-47f0-b7c3-8672c75e17dc", "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
