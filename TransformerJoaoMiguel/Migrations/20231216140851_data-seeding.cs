using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformerJoaoMiguel.Migrations
{
    public partial class dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "TipoTransformer",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 3, "Autobot"},
                { 4, "Decepticon"},
            });

            migrationBuilder.InsertData(
            table: "Transformer",
            columns: new[] { "Id", "Nome","Veiculo", "ForcaDeAtaque", "TipoTransformerId", "Imagem" },
            values: new object[,]
            {
                { 50, "Ironride", "Caminhonete", 8, 3, "ironride.jpg" },
                {70, "Sideswipe", "Corvette", 7, 3, "sideswipe.jpg" },
                { 80, "Shockwave","Nave Espacial", 8, 4, "shockwave.jpg" },
            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
