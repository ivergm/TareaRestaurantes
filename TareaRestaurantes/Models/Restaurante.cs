﻿namespace TareaRestaurantes.Models
{
   
        public class Restaurante
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Dueno { get; set; }
            public string Provincia { get; set; }
            public string Canton { get; set; }
            public string Distrito { get; set; }
            public string DireccionExacta { get; set; }
        }
    }
