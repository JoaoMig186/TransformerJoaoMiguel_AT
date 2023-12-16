using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformerJoaoMiguel.Migrations
{
    public partial class implementacaodeimagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Transformer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Transformer");
        }
    }
}
