using Microsoft.EntityFrameworkCore;

namespace Banco.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }
        
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Transacao> Transacao { get; set; }

        public DbSet<Cartoes> Cartoes { get; set; }
    }
}