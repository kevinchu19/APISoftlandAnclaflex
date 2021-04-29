using System;
using System.Collections.Generic;

#nullable disable

namespace APISoftlandAnclaflex.Models
{
    public class Usuario
    {
        public int RowID { get; set; }
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string? Idcliente { get; set; }
        public string? Idvendedor { get; set; }
        public string Password { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int Activo { get; set; }

    }
}
