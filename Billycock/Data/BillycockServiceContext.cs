﻿using Billycock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Data
{
    public class BillycockServiceContext: DbContext
    {
        public BillycockServiceContext(DbContextOptions<BillycockServiceContext> options)
       : base(options)
        { }

        public DbSet<Usuario> USUARIO { get; set; }
        public DbSet<Plataforma> PLATAFORMA { get; set; }
        public DbSet<Estado> ESTADO { get; set; }
        public DbSet<Cuenta> CUENTA { get; set; }
        public DbSet<UsuarioPlataforma> USUARIOPLATAFORMA { get; set; }
        public DbSet<PlataformaCuenta> PLATAFORMACUENTA { get; set; }
        public DbSet<BillycockHistory> HISTORY { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioPlataforma>().HasKey(up => new { up.idUsuario, up.idPlataforma,up.idCuenta});
            modelBuilder.Entity<PlataformaCuenta>().HasKey(pc => new { pc.idCuenta, pc.idPlataforma });
        }
    }
}