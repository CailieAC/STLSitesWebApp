using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STLSitesWebApp.Data.Migrations
{
    public partial class Reset2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationEditViewModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationEditViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    LocationCounty = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationEditViewModel", x => x.Id);
                });
        }
    }
}
