using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APISoftlandAnclaflex.Entities
{
    public partial class Fcrmvi
    {
        public string Fcrmvi_Tipori { get; set; }
        public string Fcrmvi_Artori { get; set; }
        public string Fcrmvi_Tipcpt { get; set; }
        public string Fcrmvi_Codcpt { get; set; }
        public string Fcrmvi_Nserie { get; set; }
        public string Fcrmvi_Ndespa { get; set; }
        public string Fcrmvi_Envase { get; set; }
        public string Fcrmvi_Notros { get; set; }
        public string Fcrmvi_Natrib { get; set; }
        public string Fcrmvi_Nestan { get; set; }
        public string Fcrmvi_Nubica { get; set; }
        public string Fcrmvi_Nfecha { get; set; }
        public string Fcrmvi_Tserie { get; set; }
        public string Fcrmvi_Tdespa { get; set; }
        public string Fcrmvi_Tenvas { get; set; }
        public string Fcrmvi_Totros { get; set; }
        public string Fcrmvi_Tatrib { get; set; }
        public string Fcrmvi_Testan { get; set; }
        public string Fcrmvi_Tubica { get; set; }
        public string Fcrmvi_Tfecha { get; set; }
        public string Fcrmvi_Deposi { get; set; }
        public string Fcrmvi_Sector { get; set; }
        public decimal? Fcrmvi_Precio { get; set; }
        public decimal? Fcrmvi_Cantid { get; set; }
        public DateTime? Fcrmvi_Fchent { get; set; }
        public DateTime? Fcrmvi_Fchhas { get; set; }
        public decimal? Fcrmvi_Pctbf1 { get; set; }
        public decimal? Fcrmvi_Pctbf2 { get; set; }
        public decimal? Fcrmvi_Pctbf3 { get; set; }
        public decimal? Fcrmvi_Pctbf4 { get; set; }
        public decimal? Fcrmvi_Pctbf5 { get; set; }
        public decimal? Fcrmvi_Pctbf6 { get; set; }
        public decimal? Fcrmvi_Pctbf7 { get; set; }
        public decimal? Fcrmvi_Pctbf8 { get; set; }
        public decimal? Fcrmvi_Pctbf9 { get; set; }
        public string Fcrmvi_Textos { get; set; }
        public string Usr_Fcrmvi_Dirent { get; set; }
        public string Usr_Fcrmvi_Diren2 { get; set; }
        public string Usr_Fcrmvi_Cndpag { get; set; }
        public string Usr_Fcrmvi_Vnddor { get; set; }
        public string Usr_Fcrmvi_Acopio { get; set; }
        public string Usr_Fcrmvi_Facant { get; set; }
        public string Usr_Fcrmvi_Trared { get; set; }
        public decimal? Usr_Fcrmvi_Totbon { get; set; }
        public decimal? Usr_Fcrmvi_Stdisp { get; set; }
        public int? Usr_Fcrmvi_Bultos { get; set; }
        public int? Usr_Fcrmvi_Palets { get; set; }
        public string Usr_Fcrmvi_Codzon { get; set; }
        public DateTime? Fcrmvi_Fecalt { get; set; }
        public DateTime? Fcrmvi_Fecmod { get; set; }
        public string Fcrmvi_Userid { get; set; }
        public string Fcrmvi_Ultopr { get; set; }
        public string Fcrmvi_Debaja { get; set; }
        public string Fcrmvi_Oalias { get; set; }

        public virtual Fcrmvh Pedido { get; set; }
    }
}
