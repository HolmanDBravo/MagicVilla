﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Modelos.Dto
{
    public class VillaUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        [Required]
        public int Ocupantes { get; set; }
        [Required]
        public double MetrosCuadrados { get; set; }
        [Required]
        public string Detalle { get; set; }
        [Required]
        public double Tarifa { get; set; }
        [Required]
        public string ImagenURL { get; set; }
        [Required]
        public string Amenidad { get; set; }        
    }
}
