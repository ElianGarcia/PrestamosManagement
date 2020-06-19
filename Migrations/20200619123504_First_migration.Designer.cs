﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrestamosApp.Data;

namespace PrestamosManagement.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200619123504_First_migration")]
    partial class First_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("PrestamosApp.Models.Moras", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Moras");
                });

            modelBuilder.Entity("PrestamosApp.Models.MorasDetalle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoraID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("MoraID");

                    b.ToTable("MorasDetalle");
                });

            modelBuilder.Entity("PrestamosApp.Models.Personas", b =>
                {
                    b.Property<int>("PersonaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<DateTime>("FechaDeNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("PersonaID");

                    b.ToTable("Personas");

                    b.HasData(
                        new
                        {
                            PersonaID = 1,
                            Balance = 345.34m,
                            Cedula = "05600345926",
                            Direccion = "Calle Roberto Acevedo #34",
                            FechaDeNacimiento = new DateTime(2020, 6, 19, 8, 35, 3, 253, DateTimeKind.Local).AddTicks(7591),
                            Nombres = "Juan Alberto",
                            Telefono = "8292655182"
                        });
                });

            modelBuilder.Entity("PrestamosApp.Models.Prestamos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonaID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Prestamos");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Balance = 345.34m,
                            Concepto = "Terrenos",
                            Fecha = new DateTime(2020, 6, 19, 8, 35, 3, 247, DateTimeKind.Local).AddTicks(3311),
                            Monto = 345.34m,
                            PersonaID = 1
                        });
                });

            modelBuilder.Entity("PrestamosApp.Models.MorasDetalle", b =>
                {
                    b.HasOne("PrestamosApp.Models.Moras", null)
                        .WithMany("MorasDetalle")
                        .HasForeignKey("MoraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}