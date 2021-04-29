using System;
using System.Collections.Generic;

#nullable disable

namespace APISoftlandAnclaflex.Models
{
    public partial class Vendedores
    {
        public int RowID { get; set; }
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int Activo { get; set; }

    }
}
