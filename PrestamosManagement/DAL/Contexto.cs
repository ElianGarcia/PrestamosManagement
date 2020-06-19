using Microsoft.EntityFrameworkCore;
using PrestamosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamosApp.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Moras> Moras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=Data\PrestamosDB.db");
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Prestamos>().HasData(new Prestamos
            {
                ID = 1,
                Fecha = DateTime.Now,
                PersonaID = 1,
                Concepto = "Terrenos",
                Monto = Convert.ToDecimal(345.34),
                Balance = Convert.ToDecimal(345.34)
            });

            model.Entity<Personas>().HasData(new Personas
            {
                PersonaID = 1,
                FechaDeNacimiento = DateTime.Now,
                Nombres = "Juan Alberto",
                Telefono = "8292655182",
                Direccion = "Calle Roberto Acevedo #34",
                Cedula = "05600345926",
                Balance = Convert.ToDecimal(345.34)
            });
        }
    }
}
