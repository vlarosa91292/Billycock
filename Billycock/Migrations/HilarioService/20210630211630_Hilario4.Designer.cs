﻿// <auto-generated />
using System;
using Billycock.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Billycock.Migrations
{
    [DbContext(typeof(HilarioServiceContext))]
    [Migration("20210630211630_Hilario4")]
    partial class Hilario4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Billycock.Models.Hilario.Linea", b =>
                {
                    b.Property<int>("idLinea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("descripcion")
                        .HasColumnType("int");

                    b.HasKey("idLinea");

                    b.ToTable("LINEA");
                });

            modelBuilder.Entity("Billycock.Models.Hilario.Oferta", b =>
                {
                    b.Property<int>("idOferta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductoidProducto")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("codigoBarra")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idEstado")
                        .HasColumnType("int");

                    b.Property<double>("precioOferta")
                        .HasColumnType("float");

                    b.HasKey("idOferta");

                    b.HasIndex("ProductoidProducto");

                    b.ToTable("OFERTA");
                });

            modelBuilder.Entity("Billycock.Models.Hilario.Producto", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LineaidLinea")
                        .HasColumnType("int");

                    b.Property<int?>("ProveedoridProveedor")
                        .HasColumnType("int");

                    b.Property<string>("codigoBarra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("idProveedor")
                        .HasColumnType("int");

                    b.Property<int>("idlinea")
                        .HasColumnType("int");

                    b.Property<int>("loteCaja")
                        .HasColumnType("int");

                    b.Property<double>("precioUnitario")
                        .HasColumnType("float");

                    b.HasKey("idProducto");

                    b.HasIndex("LineaidLinea");

                    b.HasIndex("ProveedoridProveedor");

                    b.ToTable("PRODUCTO");
                });

            modelBuilder.Entity("Billycock.Models.Hilario.Proveedor", b =>
                {
                    b.Property<int>("idProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("descripcion")
                        .HasColumnType("int");

                    b.HasKey("idProveedor");

                    b.ToTable("PROVEEDOR");
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

            modelBuilder.Entity("Billycock.Models.Hilario.Oferta", b =>
                {
                    b.HasOne("Billycock.Models.Hilario.Producto", null)
                        .WithMany("ofertas")
                        .HasForeignKey("ProductoidProducto");
                });

            modelBuilder.Entity("Billycock.Models.Hilario.Producto", b =>
                {
                    b.HasOne("Billycock.Models.Hilario.Linea", null)
                        .WithMany("productos")
                        .HasForeignKey("LineaidLinea");

                    b.HasOne("Billycock.Models.Hilario.Proveedor", null)
                        .WithMany("productos")
                        .HasForeignKey("ProveedoridProveedor");
                });

            modelBuilder.Entity("Billycock.Models.Hilario.Linea", b =>
                {
                    b.Navigation("productos");
                });

            modelBuilder.Entity("Billycock.Models.Hilario.Producto", b =>
                {
                    b.Navigation("ofertas");
                });

            modelBuilder.Entity("Billycock.Models.Hilario.Proveedor", b =>
                {
                    b.Navigation("productos");
                });
#pragma warning restore 612, 618
        }
    }
}
