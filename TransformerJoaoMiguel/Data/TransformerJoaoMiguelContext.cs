using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransformerJoaoMiguel.Models;

namespace TransformerJoaoMiguel.Data
{
    public class TransformerJoaoMiguelContext : DbContext
    {
        public TransformerJoaoMiguelContext (DbContextOptions<TransformerJoaoMiguelContext> options)
            : base(options)
        {
        }

        public DbSet<TipoTransformer> TipoTransformer { get; set; } = default!;

        public DbSet<Transformer> Transformer { get; set; }
    }
}
