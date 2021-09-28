using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoVendas.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Endereco_EnderecoId",
                table: "Pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "pessoa");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "pessoa",
                newName: "IX_pessoa_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pessoa",
                table: "pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_Endereco_EnderecoId",
                table: "pessoa",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_Endereco_EnderecoId",
                table: "pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pessoa",
                table: "pessoa");

            migrationBuilder.RenameTable(
                name: "pessoa",
                newName: "Pessoa");

            migrationBuilder.RenameIndex(
                name: "IX_pessoa_EnderecoId",
                table: "Pessoa",
                newName: "IX_Pessoa_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Endereco_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
