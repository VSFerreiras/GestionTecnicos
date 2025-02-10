﻿// <auto-generated />
using System;
using GestionTecnicos.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionTecnicos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20250210073004_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionTecnicos.Models.Ciudades", b =>
                {
                    b.Property<int>("CiudadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CiudadId"));

                    b.Property<string>("CiudadNombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("CiudadId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("GestionTecnicos.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<float>("LimiteCredito")
                        .HasColumnType("real");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rnc")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex("CiudadId")
                        .IsUnique();

                    b.HasIndex("TecnicoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GestionTecnicos.Models.Sistemas", b =>
                {
                    b.Property<int>("SistemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SistemaId"));

                    b.Property<double>("Complejidad")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("SistemaId");

                    b.ToTable("Sistemas");
                });

            modelBuilder.Entity("GestionTecnicos.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TecnicoId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("SueldoHora")
                        .HasColumnType("real");

                    b.HasKey("TecnicoId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("GestionTecnicos.Models.Tickets", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Prioridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TiempoInvertido")
                        .HasColumnType("float");

                    b.HasKey("TicketId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("GestionTecnicos.Models.Clientes", b =>
                {
                    b.HasOne("GestionTecnicos.Models.Ciudades", "Ciudad")
                        .WithOne("Cliente")
                        .HasForeignKey("GestionTecnicos.Models.Clientes", "CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionTecnicos.Models.Tecnicos", "Tecnico")
                        .WithMany()
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("GestionTecnicos.Models.Tickets", b =>
                {
                    b.HasOne("GestionTecnicos.Models.Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("GestionTecnicos.Models.Ciudades", b =>
                {
                    b.Navigation("Cliente")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
