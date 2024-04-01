using API.Entidades;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base (options)
        {            
        }

        public DbSet<Aeroporto> Aeroportos { get; set; }
        public DbSet<Bagagem> Bagagens { get; set; }        
        public DbSet<Passagem> Passagens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voo> Voos { get; set; }        
    }
}