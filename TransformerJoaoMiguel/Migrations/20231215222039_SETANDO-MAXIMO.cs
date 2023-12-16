using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformerJoaoMiguel.Migrations
{
    public partial class SETANDOMAXIMO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Velocidade",
                table: "Transformer",
                newName: "ForcaDeAtaque");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ForcaDeAtaque",
                table: "Transformer",
                newName: "Velocidade");
        }
    }
}
