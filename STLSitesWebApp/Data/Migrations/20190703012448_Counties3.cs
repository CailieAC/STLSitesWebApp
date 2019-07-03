using Microsoft.EntityFrameworkCore.Migrations;

namespace STLSitesWebApp.Data.Migrations
{
    public partial class Counties3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationRating_Location_LocationId",
                table: "LocationRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationRating",
                table: "LocationRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "LocationRating",
                newName: "LocationRatings");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_LocationRating_LocationId",
                table: "LocationRatings",
                newName: "IX_LocationRatings_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationRatings",
                table: "LocationRatings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationRatings_Locations_LocationId",
                table: "LocationRatings",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationRatings_Locations_LocationId",
                table: "LocationRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationRatings",
                table: "LocationRatings");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "LocationRatings",
                newName: "LocationRating");

            migrationBuilder.RenameIndex(
                name: "IX_LocationRatings_LocationId",
                table: "LocationRating",
                newName: "IX_LocationRating_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationRating",
                table: "LocationRating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationRating_Location_LocationId",
                table: "LocationRating",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
