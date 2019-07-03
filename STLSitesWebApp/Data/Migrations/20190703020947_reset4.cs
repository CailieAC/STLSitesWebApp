using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STLSitesWebApp.Data.Migrations
{
    public partial class reset4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationRatings_LocationDetailsViewModel_LocationDetailsViewModelId",
                table: "LocationRatings");

            migrationBuilder.DropTable(
                name: "LocationDetailsViewModel");

            migrationBuilder.DropIndex(
                name: "IX_LocationRatings_LocationDetailsViewModelId",
                table: "LocationRatings");

            migrationBuilder.DropColumn(
                name: "LocationDetailsViewModelId",
                table: "LocationRatings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationDetailsViewModelId",
                table: "LocationRatings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationDetailsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDetailsViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationRatings_LocationDetailsViewModelId",
                table: "LocationRatings",
                column: "LocationDetailsViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationRatings_LocationDetailsViewModel_LocationDetailsViewModelId",
                table: "LocationRatings",
                column: "LocationDetailsViewModelId",
                principalTable: "LocationDetailsViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
