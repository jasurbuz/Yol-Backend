using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yol.Data.Migrations
{
    public partial class news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CreatedTime",
                table: "Newses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Newses",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("17f7b330-c8cd-4921-962c-dd44d6c5d510"), "5ac25c35-c8c4-4cae-a3d1-06ccd27750fe", "Admin", "ADMIN" },
                    { new Guid("a7eeaca7-52df-46d9-81a2-ec016f4aae0b"), "be66a739-8e69-402e-be5b-d66ce4e47db9", "SuperAdmin", "SUPERADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17f7b330-c8cd-4921-962c-dd44d6c5d510"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a7eeaca7-52df-46d9-81a2-ec016f4aae0b"));

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Newses");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Newses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d1e7d1f-2c41-43b4-a8e1-4b4aa2b57908"), "37643355-457f-4ab5-ae22-fac9cd548526", "Admin", "ADMIN" },
                    { new Guid("7b921da4-35d1-4c14-b368-cebd096ad4ff"), "a16e5aa8-4d08-4326-b853-fb9227888859", "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
