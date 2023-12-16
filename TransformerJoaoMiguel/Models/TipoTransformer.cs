using Microsoft.Build.Framework;

namespace TransformerJoaoMiguel.Models
{
    public class TipoTransformer : GlobalId
    {
        [Required]
        public string Name { get; set; }
    }
}
