using System;
using System.Collections.Generic;

#nullable disable

namespace APISoftlandAnclaflex.Models
{
    public class CuentaCorriente
    {
        public string? Empresa { get; set; }
        public string? Codigoformulario { get; set; }
        public int? Numeroformulario { get; set; }
        public string Empresaaplicacion { get; set; }
        public string Formularioaplicacion { get; set; }
        public int Numeroformularioaplicacion { get; set; }
        public int Cuota { get; set; }
        public string Idcliente { get; set; }
        public DateTime Fechamovimiento { get; set; }
        public DateTime Fechavencimiento { get; set; }
        public decimal Importenacional { get; set; }
        public decimal Importeextranjera { get; set; }
        public string IdVendedor { get; set; }
        public string TipoRegistro { get; set; }
        public string PdfPath { get; set; }

        public int RowID { get; set; }
        public string Id { get; set; }
        public string Sfl_TableOperation { get; set; }

    }
}
