using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APISoftlandAnclaflex.Entities
{
    public partial class Fcrmvh
    {
        public string Fcrmvh_Nrocta { get; set; }
        public DateTime Fcrmvh_Fchmov { get; set; }
        public string Fcrmvh_Dirent { get; set; }
        public string Fcrmvh_Paient { get; set; }
        public string Fcrmvh_Codent { get; set; }
        public string Fcrmvh_Camion { get; set; }
        public string Fcrmvh_Vnddor { get; set; }
        public string Fcrmvh_Cndpag { get; set; }
        public string Fcrmvh_Codlis { get; set; }
        public string Fcrmvh_Textos { get; set; }
        public string Fcrmvh_Coflis { get; set; }
        public string Fcrmvh_Coffac { get; set; }
        public string Fcrmvh_Cofdeu { get; set; }
        public string Fcrmvh_Nombre { get; set; }
        public string Fcrmvh_Direcc { get; set; }
        public string Fcrmvh_Codpai { get; set; }
        public string Fcrmvh_Codpos { get; set; }
        public string Fcrmvh_Coniva { get; set; }
        public string Fcrmvh_Cntpdc { get; set; }
        public string Fcrmvh_Nrodoc { get; set; }
        public string Fcrmvh_Jurisd { get; set; }
        public string Fcrmvh_Cndiva { get; set; }
        public DateTime? Fcrmvh_Fchdes { get; set; }
        public DateTime? Fcrmvh_Fchhas { get; set; }
        public string Fcrmvh_Contac { get; set; }
        public string Fcrmvh_Telefn { get; set; }
        public string Fcrmvh_Codzon { get; set; }
        public string Fcrmvh_Municp { get; set; }
        public string Fcrmvh_Cdent1 { get; set; }
        public string Fcrmvh_Cdent2 { get; set; }
        public string Fcrmvh_Comori { get; set; }
        public string Fcrmvh_Codori { get; set; }
        public string Fcrmvh_Jurctd { get; set; }
        public string Fcrmvh_Cndcom { get; set; }
        public string Fcrmvh_Tipexp { get; set; }
        public short? Usr_Fcrmvh_Estaut { get; set; }
        public string Usr_Fcrmvh_Retira { get; set; }
        public string Usr_Fcrmvh_Acopio { get; set; }
        public string Usr_Fcrmvh_Facant { get; set; }
        public int? Usr_Fcrmvh_Nrolem { get; set; }
        public string Usr_Fcrmvh_Trared { get; set; }
        public string Usr_Fcrmvh_Nrorem { get; set; }
        public string Usr_Fcrmvh_Muedon { get; set; }
        public string Usr_Fcrmvh_Consig { get; set; }
        public string Usr_Fcrmvh_Logist { get; set; }
        public short? Usr_Fcrmvh_Autcom { get; set; }
        public string Usr_Fcrmvh_Usrcom { get; set; }
        public DateTime? Usr_Fcrmvh_Fecaut { get; set; }
        public string Usr_Fcrmvh_Obscom { get; set; }
        public string Usr_Fcrmvh_Direml { get; set; }
        public string Usr_Fcrmvh_Dirmod { get; set; }
        public string Usr_Fcrmvh_Userpw { get; set; }
        public virtual int Virt_Nroffc { get; set; }
        public virtual ICollection<Fcrmvi> Items{ get; set; }
    }
}
