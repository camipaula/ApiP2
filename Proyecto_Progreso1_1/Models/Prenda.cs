﻿using System.ComponentModel.DataAnnotations;

namespace Proyecto_Progreso1_1.Models
{
    public class Prenda
    {
        public int IdPrenda { get; set; }
        
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }

        public float Precio { get; set; }

    }
}
