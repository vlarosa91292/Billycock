using Billycock.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Data
{
    public class BillycockServiceContext: DbContext
    {
        public BillycockServiceContext(IConfiguration configuration) : base(GetOptions(configuration))
        {
        }

        private static DbContextOptions GetOptions(IConfiguration configuration)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = configuration["Server"],
                InitialCatalog = configuration["Database_B"],
                UserID = configuration["UserId"],
                Password = configuration["Password"],
                ApplicationName = "Billycock"
            };
            if(builder.UserID != "sa")
            {
                builder.MultipleActiveResultSets = true;
                builder.PersistSecurityInfo = false;
                builder.Encrypt = true;
                builder.TrustServerCertificate = false;
            }
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), builder.ConnectionString).Options;
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
