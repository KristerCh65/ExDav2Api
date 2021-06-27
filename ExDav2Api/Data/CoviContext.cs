using ExDav2Api.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Data
{
    public class CoviContext : DbContext
    {
        public DbSet<PuestoVacunacion> PuestosVacunacion { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<CitaVacunacion> CitasVacunacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTP-KCH;Database=CovidExDAV;Trusted_Connection=true;");
        }
    }
}
