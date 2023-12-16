using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransformerJoaoMiguel.Models
{
    public class Transformer : GlobalId
    {
        [Microsoft.Build.Framework.Required]
        public string Nome { get; set; }
        public string? Imagem { get; set; }
        [NotMapped]
        public IFormFile FotoUpload { get; set; }
        [Microsoft.Build.Framework.Required]
        public string Veiculo { get; set; }
        [Microsoft.Build.Framework.Required]
        [Range(1, 10, ErrorMessage = "A Força de Ataque deve estar entre 1 e 10.")]
        public int ForcaDeAtaque { get; set; }

        [Microsoft.Build.Framework.Required]
        public int TipoTransformerId { get; set; }
        public TipoTransformer? TipoTransformer { get; set; }
    }
}
