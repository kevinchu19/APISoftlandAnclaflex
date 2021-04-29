using Newtonsoft.Json;
using System;
using System.Collections.Generic;


#nullable disable

namespace APISoftlandAnclaflex.Models
{
    public class Cliente
    {
        public int RowID { get; set; }
        public string Id { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string DireccionFacturacion { get; set; }
        public string PaisFacturacion { get; set; }
        public string CodigoPostalFacturacion { get; set; }
        public string ProvinciaFacturacion { get; set; }
        public string DireccionEntrega { get; set; }
        public string PaisEntrega { get; set; }
        public string CodigoPostalEntrega { get; set; }
        public string ProvinciaEntrega { get; set; }
        public string ListaPrecios { get; set; }
        public string LocalidadFacturacion { get; set; }
        public string LocalidadEntrega { get; set; }
        public string? TransportistaRedespacho { get; set; }
        public string? IdVendedor { get; set; }
        public string? GrupoBonificacion { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int Activo { get; set; }

    }
}


