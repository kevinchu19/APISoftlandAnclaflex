using System;
using System.Collections.Generic;

#nullable disable

namespace APISoftlandAnclaflex.Models
{
    public class Bonificacion
    {
        public int RowID { get; set; }
        public int Id { get; set; }
        public string Idgrupobonificacion { get; set; }
        public string Tipoproducto { get; set; }
        public int Idnumerorubro { get; set; }
        public string Valorrubro { get; set; }
        public decimal? Bonificacion1 { get; set; }
        public decimal? Bonificacion2 { get; set; }
        public decimal? Bonificacion3 { get; set; }
        public string Sfl_TableOperation { get; set; }

        public int Activo { get; set; }
        
    }
}
