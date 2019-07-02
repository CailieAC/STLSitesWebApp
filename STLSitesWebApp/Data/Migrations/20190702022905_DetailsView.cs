using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STLSitesWebApp.Data.Migrations
{
    public partial class DetailsView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationDetailsViewModelId",
                table: "LocationRating",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationDetailsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDetailsViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationRating_LocationDetailsViewModelId",
                table: "LocationRating",
                column: "LocationDetailsViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationRating_LocationDetailsViewModel_LocationDetailsViewModelId",
                table: "LocationRating",
                column: "LocationDetailsViewModelId",
                principalTable: "LocationDetailsViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationRating_LocationDetailsViewModel_LocationDetailsViewModelId",
                table: "LocationRating");

            migrationBuilder.DropTable(
                name: "LocationDetailsViewModel");

            migrationBuilder.DropIndex(
                name: "IX_LocationRating_LocationDetailsViewModelId",
                table: "LocationRating");

            migrationBuilder.DropColumn(
                name: "LocationDetailsViewModelId",
                table: "LocationRating");
        }
    }
}
