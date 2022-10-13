using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace APISoftlandAnclaflex.Models
{
    public class Producto
    {
        public int RowID { get; set; }
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string TipoProducto { get; set; }
        public string Rubro1 { get; set; }
        public string Rubro2 { get; set; }
        public string ClienteExclusivo{ get; set; }
        public decimal? Pesokg { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int Activo { get; set; }
        public string Visibilidad { get; set; }

    }
}
