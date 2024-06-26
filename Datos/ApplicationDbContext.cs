﻿using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDbContext : DbContext
    {   

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
            
        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la Villa....",
                    ImagenURL = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 40,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Premium vista a la piscina",
                    Detalle = "Premium de la Villa....",
                    ImagenURL = "",
                    Ocupantes = 4,
                    Tarifa = 150,
                    Amenidad = "",
                    MetrosCuadrados=50,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                }
                );
        }


    }
}
