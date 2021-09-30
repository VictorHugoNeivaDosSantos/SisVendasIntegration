using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoVendas.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SobreNome",
                table: "pessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SobreNome",
                table: "pessoa",
                type: "text",
                nullable: true);
        }
    }
}
