using Microsoft.EntityFrameworkCore.Migrations;

namespace Yol.Data.Migrations
{
    public partial class ModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SucessfullPlans",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Companies",
                newName: "SucessfullPlansFileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SucessfullPlansFileName",
                table: "Companies",
                newName: "FileName");

            migrationBuilder.AddColumn<int>(
                name: "SucessfullPlans",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
