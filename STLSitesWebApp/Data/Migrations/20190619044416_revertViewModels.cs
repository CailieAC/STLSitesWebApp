using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STLSitesWebApp.Data.Migrations
{
    public partial class revertViewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationRating_Location_LocationId",
                table: "LocationRating");

            migrationBuilder.DropIndex(
                name: "IX_LocationRating_LocationId",
                table: "LocationRating");

            migrationBuilder.CreateTable(
                name: "LocationCreateViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationCreateViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationListItemViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationListItemViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationCreateViewModel");

            migrationBuilder.DropTable(
                name: "LocationListItemViewModel");

            migrationBuilder.CreateIndex(
                name: "IX_LocationRating_LocationId",
                table: "LocationRating",
                column: "LocationId");

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
