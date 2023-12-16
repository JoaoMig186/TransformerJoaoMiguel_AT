using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformerJoaoMiguel.Migrations
{
    public partial class InitialTransformers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transformer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Veiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Velocidade = table.Column<int>(type: "int", nullable: false),
                    TipoTransformerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transformer_TipoTransformer_TipoTransformerId",
                        column: x => x.TipoTransformerId,
                        principalTable: "TipoTransformer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_TipoTransformerId",
                table: "Transformer",
                column: "TipoTransformerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transformer");
        }
    }
}
