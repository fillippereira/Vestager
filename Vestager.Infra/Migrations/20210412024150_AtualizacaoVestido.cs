using Microsoft.EntityFrameworkCore.Migrations;

namespace Vestager.Infra.Migrations
{
    public partial class AtualizacaoVestido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlVestido",
                table: "Vestidos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlVestido",
                table: "Vestidos");
        }
    }
}
