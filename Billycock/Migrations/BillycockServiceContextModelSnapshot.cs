﻿// <auto-generated />
using System;
using Billycock.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Billycock.Migrations
{
    [DbContext(typeof(BillycockServiceContext))]
    partial class BillycockServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Billycock.Models.Cuenta", b =>
                {
                    b.Property<int>("idCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("diminutivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idEstado")
                        .HasColumnType("int");

                    b.HasKey("idCuenta");

                    b.ToTable("CUENTA");
                });

            modelBuilder.Entity("Billycock.Models.Estado", b =>
                {
                    b.Property<int>("idEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idEstado");

                    b.ToTable("ESTADO");
                });

            modelBuilder.Entity("Billycock.Models.Historia", b =>
                {
                    b.Property<int>("idHistory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Request")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("integracion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idHistory");

                    b.ToTable("HISTORIA");
                });

            modelBuilder.Entity("Billycock.Models.Plataforma", b =>
                {
                    b.Property<int>("idPlataforma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idEstado")
                        .HasColumnType("int");

                    b.Property<int?>("numeroMaximoUsuarios")
                        .HasColumnType("int");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.HasKey("idPlataforma");

                    b.ToTable("PLATAFORMA");
                });

            modelBuilder.Entity("Billycock.Models.PlataformaCuenta", b =>
                {
                    b.Property<string>("idPlataformaCuenta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fechaPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCuenta")
                        .HasColumnType("int");

                    b.Property<int>("idPlataforma")
                        .HasColumnType("int");

                    b.Property<int?>("usuariosdisponibles")
                        .HasColumnType("int");

                    b.HasKey("idPlataformaCuenta");

                    b.HasIndex("idCuenta");

                    b.HasIndex("idPlataforma");

                    b.ToTable("PLATAFORMACUENTA");
                });

            modelBuilder.Entity("Billycock.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("facturacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("fechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("idEstado")
                        .HasColumnType("int");

                    b.Property<int?>("pago")
                        .HasColumnType("int");

                    b.Property<string>("pin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUsuario");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("Billycock.Models.UsuarioPlataformaCuenta", b =>
                {
                    b.Property<string>("idUsuarioPlataformaCuenta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("idCuenta")
                        .HasColumnType("int");

                    b.Property<int>("idPlataforma")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("idUsuarioPlataformaCuenta");

                    b.HasIndex("idCuenta");

                    b.HasIndex("idPlataforma");

                    b.HasIndex("idUsuario");

                    b.ToTable("USUARIOPLATAFORMACUENTA");
                });

            modelBuilder.Entity("Billycock.Models.PlataformaCuenta", b =>
                {
                    b.HasOne("Billycock.Models.Cuenta", "Cuenta")
                        .WithMany("plataformaCuentas")
                        .HasForeignKey("idCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Billycock.Models.Plataforma", "Plataforma")
                        .WithMany("plataformaCuentas")
                        .HasForeignKey("idPlataforma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");

                    b.Navigation("Plataforma");
                });

            modelBuilder.Entity("Billycock.Models.UsuarioPlataformaCuenta", b =>
                {
                    b.HasOne("Billycock.Models.Cuenta", "Cuenta")
                        .WithMany("usuarioPlataformaCuentas")
                        .HasForeignKey("idCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Billycock.Models.Plataforma", "Plataforma")
                        .WithMany("usuarioPlataformaCuentas")
                        .HasForeignKey("idPlataforma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Billycock.Models.Usuario", "Usuario")
                        .WithMany("usuarioPlataformaCuentas")
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");

                    b.Navigation("Plataforma");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Billycock.Models.Cuenta", b =>
                {
                    b.Navigation("plataformaCuentas");

                    b.Navigation("usuarioPlataformaCuentas");
                });

            modelBuilder.Entity("Billycock.Models.Plataforma", b =>
                {
                    b.Navigation("plataformaCuentas");

                    b.Navigation("usuarioPlataformaCuentas");
                });

            modelBuilder.Entity("Billycock.Models.Usuario", b =>
                {
                    b.Navigation("usuarioPlataformaCuentas");
                });
#pragma warning restore 612, 618
        }
    }
}
