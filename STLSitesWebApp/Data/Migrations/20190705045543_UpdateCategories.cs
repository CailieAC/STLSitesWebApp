using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STLSitesWebApp.Data.Migrations
{
    public partial class UpdateCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLocations_ViewCategoryViewModel_ViewCategoryViewModelId",
                table: "CategoryLocations");

            migrationBuilder.DropTable(
                name: "ViewCategoryViewModel");

            migrationBuilder.DropIndex(
                name: "IX_CategoryLocations_ViewCategoryViewModelId",
                table: "CategoryLocations");

            migrationBuilder.DropColumn(
                name: "ViewCategoryViewModelId",
                table: "CategoryLocations");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CategoryLocations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryLocations");

            migrationBuilder.AddColumn<int>(
                name: "ViewCategoryViewModelId",
                table: "CategoryLocations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ViewCategoryViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewCategoryViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewCategoryViewModel_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLocations_ViewCategoryViewModelId",
                table: "CategoryLocations",
                column: "ViewCategoryViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCategoryViewModel_CategoryId",
                table: "ViewCategoryViewModel",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLocations_ViewCategoryViewModel_ViewCategoryViewModelId",
                table: "CategoryLocations",
                column: "ViewCategoryViewModelId",
                principalTable: "ViewCategoryViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
