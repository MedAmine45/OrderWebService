using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIPerspection.Migrations
{
    public partial class TubeAndAnalyse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Analyse",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tube",
                table: "Prescription",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Analyse",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Tube",
                table: "Prescription");
        }
    }
}
