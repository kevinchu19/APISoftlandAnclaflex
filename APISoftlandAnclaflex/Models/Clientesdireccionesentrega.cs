using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace APISoftlandAnclaflex.Models
{
    public class Clientesdireccionesentrega
    {
        public int RowID { get; set; }
        public string IdCliente { get; set; }
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string DireccionEntrega { get; set; }
        public string Paisentrega { get; set; }
        public string CodigoPostalEntrega { get; set; }
        public string? LocalidadEntrega { get; set; }
        public string? ProvinciaEntrega { get; set; }
        public string? TransportistaRedespacho { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int Activo { get; set; }
    }
}
