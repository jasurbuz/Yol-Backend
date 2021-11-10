using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yol.Data.Migrations
{
    public partial class Road : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Roads",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Roads_AdminId",
                table: "Roads",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roads_AspNetUsers_AdminId",
                table: "Roads",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roads_AspNetUsers_AdminId",
                table: "Roads");

            migrationBuilder.DropIndex(
                name: "IX_Roads_AdminId",
                table: "Roads");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Roads");
        }
    }
}
