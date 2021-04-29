using System;
using System.Collections.Generic;

#nullable disable

namespace APISoftlandAnclaflex.Models
{
    public class Listasdeprecio
    {
        public int RowID { get; set; }
        public int Id { get; set; }
        public string Idproducto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? Precio { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int Activo { get; set; }
    }
}
