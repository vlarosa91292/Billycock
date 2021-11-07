using Billycock.Models;
using Microsoft.EntityFrameworkCore;

namespace Billycock.Data
{
    public class BillycockServiceContext: DbContext
    {
        public BillycockServiceContext(DbContextOptions<BillycockServiceContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> USUARIO { get; set; }
        public DbSet<Plataforma> PLATAFORMA { get; set; }
        public DbSet<Estado> ESTADO { get; set; }
        public DbSet<Cuenta> CUENTA { get; set; }
        public DbSet<UsuarioPlataformaCuenta> USUARIOPLATAFORMACUENTA { get; set; }
        public DbSet<PlataformaCuenta> PLATAFORMACUENTA { get; set; }
        public DbSet<Historia> HISTORIA { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        } 
    }
}
