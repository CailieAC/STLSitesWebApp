using Microsoft.EntityFrameworkCore.Migrations;

namespace STLSitesWebApp.Data.Migrations
{
    public partial class Counties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "LocationDetailsViewModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationCounty",
                table: "Location",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "LocationDetailsViewModel");

            migrationBuilder.DropColumn(
                name: "LocationCounty",
                table: "Location");
        }
    }
}
