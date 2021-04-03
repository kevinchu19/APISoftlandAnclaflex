using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APISoftlandAnclaflex.Entities
{
    public partial class ANCLAFContext : DbContext
    {
        public ANCLAFContext()
        {
        }

        public ANCLAFContext(DbContextOptions<ANCLAFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fcrmvh> Fcrmvh_ { get; set; }
        public virtual DbSet<Fcrmvi> Fcrmvi { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fcrmvh>(entity =>
            {
                entity.HasKey(e => new { e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor });

                entity.ToTable("FCRMVH");

                entity.HasIndex(e => e.Fcrmvh_Nrofor)
                    .HasName("GR_NUMERATION");

                entity.HasIndex(e => new { e.Fcrmvh_Empost, e.Fcrmvh_Modost, e.Fcrmvh_Codost, e.Fcrmvh_Nroost })
                    .HasName("W_ST_STRMVZ");

                entity.HasIndex(e => new { e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Accfst })
                    .HasName("P_ST_STTEVHWIZ");

                entity.HasIndex(e => new { e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Fchmov })
                    .HasName("W_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvh_Estaut, e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Fchmov })
                    .HasName("W_GR_FCRMVH4");

                entity.HasIndex(e => new { e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Nrosub, e.Fcrmvh_Circom, e.Fcrmvh_Cirapl })
                    .HasName("GR_LIMITECREDITO");

                entity.HasIndex(e => new { e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Nrocta, e.Fcrmvh_Circom, e.Fcrmvh_Deposi, e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Sector })
                    .HasName("T_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Circom, e.Fcrmvh_Nrosub, e.Fcrmvh_Cndpag, e.Fcrmvh_Cndiva, e.Fcrmvh_Cirapl, e.Fcrmvh_Coflis })
                    .HasName("W_GR_FCRMVH3");

                entity.HasIndex(e => new { e.Fcrmvh_Nrosub, e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Circom, e.Fcrmvh_Cirapl, e.Fcrmvh_Cndpag, e.Fcrmvh_Coflis, e.Fcrmvh_Cndiva })
                    .HasName("W_GR_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvh_Circom, e.Fcrmvh_Nrocta, e.Fcrmvh_Deposi, e.Fcrmvh_Sector, e.Fcrmvh_Codlis, e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Cirapl, e.Fcrmvh_Cndpag })
                    .HasName("W_GR_FCRMVH1");

                entity.HasIndex(e => new { e.Fcrmvh_Nroost, e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Cndpag, e.Fcrmvh_Tracod, e.Fcrmvh_Trcuit, e.Fcrmvh_Trandr, e.Fcrmvh_Empost, e.Fcrmvh_Modost, e.Fcrmvh_Codost })
                    .HasName("W_GR_FCRMVH2");

                entity.HasIndex(e => new { e.Fcrmvh_Circom, e.Fcrmvh_Cirapl, e.Fcrmvh_Fchmov, e.Fcrmvh_Nrocta, e.Fcrmvh_Cofdeu, e.Fcrmvh_Camuss, e.Fcrmvh_Estaut, e.Fcrmvh_Camsec, e.Fcrmvh_Codori, e.Usr_Fcrmvh_Autcom, e.Usr_Fcrmvh_Facant, e.Fcrmvh_Codemp, e.Fcrmvh_Modfor, e.Fcrmvh_Vnddor })
                    .HasName("USR_op01");

                entity.Property(e => e.Fcrmvh_Codemp)
                    .HasColumnName("FCRMVH_CODEMP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Modfor)
                    .HasColumnName("FCRMVH_MODFOR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codfor)
                    .HasColumnName("FCRMVH_CODFOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Nrofor).HasColumnName("FCRMVH_NROFOR");

                entity.Property(e => e.Fcrmvh_Accfst)
                    .HasColumnName("FCRMVH_ACCFST")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Aerpue)
                    .HasColumnName("FCRMVH_AERPUE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Auxdev)
                    .HasColumnName("FCRMVH_AUXDEV")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Bmpbmp)
                    .HasColumnName("FCRMVH_BMPBMP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Cambio)
                    .HasColumnName("FCRMVH_CAMBIO")
                    .HasColumnType("numeric(20, 8)");

                entity.Property(e => e.Fcrmvh_Camion)
                    .HasColumnName("FCRMVH_CAMION")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Camsec)
                    .HasColumnName("FCRMVH_CAMSEC")
                    .HasColumnType("numeric(20, 8)");

                entity.Property(e => e.Fcrmvh_Camuss)
                    .HasColumnName("FCRMVH_CAMUSS")
                    .HasColumnType("numeric(20, 8)");

                entity.Property(e => e.Fcrmvh_Canant)
                    .HasColumnName("FCRMVH_CANANT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Cdent1)
                    .HasColumnName("FCRMVH_CDENT1")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Cdent2)
                    .HasColumnName("FCRMVH_CDENT2")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Cirapl)
                    .IsRequired()
                    .HasColumnName("FCRMVH_CIRAPL")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Circom)
                    .IsRequired()
                    .HasColumnName("FCRMVH_CIRCOM")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Cirgen)
                    .IsRequired()
                    .HasColumnName("FCRMVH_CIRGEN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Claaut).HasColumnName("FCRMVH_CLAAUT");

                entity.Property(e => e.Fcrmvh_Clasif)
                    .HasColumnName("FCRMVH_CLASIF")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Clprfa)
                    .HasColumnName("FCRMVH_CLPRFA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Cndcom)
                    .HasColumnName("FCRMVH_CNDCOM")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Cndiva)
                    .HasColumnName("FCRMVH_CNDIVA")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Cndpag)
                    .IsRequired()
                    .HasColumnName("FCRMVH_CNDPAG")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Cntpdc)
                    .HasColumnName("FCRMVH_CNTPDC")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codent)
                    .HasColumnName("FCRMVH_CODENT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codfcr)
                    .HasColumnName("FCRMVH_CODFCR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codfst)
                    .HasColumnName("FCRMVH_CODFST")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codgen)
                    .IsRequired()
                    .HasColumnName("FCRMVH_CODGEN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codlis)
                    .IsRequired()
                    .HasColumnName("FCRMVH_CODLIS")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Codocj)
                    .HasColumnName("FCRMVH_CODOCJ")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codopr)
                    .HasColumnName("FCRMVH_CODOPR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codori)
                    .HasColumnName("FCRMVH_CODORI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codost)
                    .HasColumnName("FCRMVH_CODOST")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codpai)
                    .HasColumnName("FCRMVH_CODPAI")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codpos)
                    .HasColumnName("FCRMVH_CODPOS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Codzon)
                    .HasColumnName("FCRMVH_CODZON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Cofdeu)
                    .HasColumnName("FCRMVH_COFDEU")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Coffac)
                    .HasColumnName("FCRMVH_COFFAC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Coflis)
                    .HasColumnName("FCRMVH_COFLIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Comori)
                    .HasColumnName("FCRMVH_COMORI")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Conbon)
                    .HasColumnName("FCRMVH_CONBON")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Congel)
                    .HasColumnName("FCRMVH_CONGEL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Coniva)
                    .HasColumnName("FCRMVH_CONIVA")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Contac)
                    .HasColumnName("FCRMVH_CONTAC")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Ctaen1)
                    .HasColumnName("FCRMVH_CTAEN1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Ctaen2)
                    .HasColumnName("FCRMVH_CTAEN2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Debaja)
                    .HasColumnName("FCRMVH_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Deposi)
                    .HasColumnName("FCRMVH_DEPOSI")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Deptra)
                    .HasColumnName("FCRMVH_DEPTRA")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Diadi1).HasColumnName("FCRMVH_DIADI1");

                entity.Property(e => e.Fcrmvh_Diadi2).HasColumnName("FCRMVH_DIADI2");

                entity.Property(e => e.Fcrmvh_Diadi3).HasColumnName("FCRMVH_DIADI3");

                entity.Property(e => e.Fcrmvh_Diaent).HasColumnName("FCRMVH_DIAENT");

                entity.Property(e => e.Fcrmvh_Dialib)
                    .HasColumnName("FCRMVH_DIALIB")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Fcrmvh_Dimobl)
                    .HasColumnName("FCRMVH_DIMOBL")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Dimori)
                    .HasColumnName("FCRMVH_DIMORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Direcc)
                    .HasColumnName("FCRMVH_DIRECC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Dirent)
                    .HasColumnName("FCRMVH_DIRENT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Docfis)
                    .HasColumnName("FCRMVH_DOCFIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Edvacp)
                    .HasColumnName("FCRMVH_EDVACP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Embarq)
                    .HasColumnName("FCRMVH_EMBARQ")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Empfcr)
                    .HasColumnName("FCRMVH_EMPFCR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Empfst)
                    .HasColumnName("FCRMVH_EMPFST")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Empgen)
                    .IsRequired()
                    .HasColumnName("FCRMVH_EMPGEN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Empocj)
                    .HasColumnName("FCRMVH_EMPOCJ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Empost)
                    .HasColumnName("FCRMVH_EMPOST")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Estaut).HasColumnName("FCRMVH_ESTAUT");

                entity.Property(e => e.Fcrmvh_Fchaut)
                    .HasColumnName("FCRMVH_FCHAUT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvh_Fchdes)
                    .HasColumnName("FCRMVH_FCHDES")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvh_Fchhas)
                    .HasColumnName("FCRMVH_FCHHAS")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvh_Fchmov)
                    .HasColumnName("FCRMVH_FCHMOV")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvh_Fchven)
                    .HasColumnName("FCRMVH_FCHVEN")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvh_Fecalt)
                    .HasColumnName("FCRMVH_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvh_Fecfcr)
                    .HasColumnName("FCRMVH_FECFCR")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvh_Feclis)
                    .HasColumnName("FCRMVH_FECLIS")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvh_Fecmod)
                    .HasColumnName("FCRMVH_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvh_Grubon)
                    .HasColumnName("FCRMVH_GRUBON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Horent)
                    .HasColumnName("FCRMVH_HORENT")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Impres).HasColumnName("FCRMVH_IMPRES");

                entity.Property(e => e.Fcrmvh_Imptcn)
                    .HasColumnName("FCRMVH_IMPTCN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Isprct)
                    .HasColumnName("FCRMVH_ISPRCT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Jurctd)
                    .HasColumnName("FCRMVH_JURCTD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Jurisd)
                    .IsRequired()
                    .HasColumnName("FCRMVH_JURISD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Letfis)
                    .HasColumnName("FCRMVH_LETFIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Mascar)
                    .HasColumnName("FCRMVH_MASCAR")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Modfcr)
                    .HasColumnName("FCRMVH_MODFCR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Modfst)
                    .HasColumnName("FCRMVH_MODFST")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Modgen)
                    .HasColumnName("FCRMVH_MODGEN")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Modocj)
                    .HasColumnName("FCRMVH_MODOCJ")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Modost)
                    .HasColumnName("FCRMVH_MODOST")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Modulo)
                    .HasColumnName("FCRMVH_MODULO")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Motdev)
                    .HasColumnName("FCRMVH_MOTDEV")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Municp)
                    .HasColumnName("FCRMVH_MUNICP")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Nombre)
                    .HasColumnName("FCRMVH_NOMBRE")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Nrocae)
                    .HasColumnName("FCRMVH_NROCAE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Nrocta)
                    .IsRequired()
                    .HasColumnName("FCRMVH_NROCTA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Nrodoc)
                    .HasColumnName("FCRMVH_NRODOC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Nrofcr).HasColumnName("FCRMVH_NROFCR");

                entity.Property(e => e.Fcrmvh_Nrofis).HasColumnName("FCRMVH_NROFIS");

                entity.Property(e => e.Fcrmvh_Nrofst).HasColumnName("FCRMVH_NROFST");

                entity.Property(e => e.Fcrmvh_Nrogen).HasColumnName("FCRMVH_NROGEN");

                entity.Property(e => e.Fcrmvh_Nroocj).HasColumnName("FCRMVH_NROOCJ");

                entity.Property(e => e.Fcrmvh_Nroost).HasColumnName("FCRMVH_NROOST");

                entity.Property(e => e.Fcrmvh_Nrosub)
                    .HasColumnName("FCRMVH_NROSUB")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Oalias)
                    .HasColumnName("FCRMVH_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Oleole)
                    .HasColumnName("FCRMVH_OLEOLE")
                    .HasColumnType("text");

                entity.Property(e => e.Fcrmvh_Paient)
                    .HasColumnName("FCRMVH_PAIENT")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Pctbf1)
                    .HasColumnName("FCRMVH_PCTBF1")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctbf2)
                    .HasColumnName("FCRMVH_PCTBF2")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctbf3)
                    .HasColumnName("FCRMVH_PCTBF3")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctbf4)
                    .HasColumnName("FCRMVH_PCTBF4")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctbf5)
                    .HasColumnName("FCRMVH_PCTBF5")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctbl1)
                    .HasColumnName("FCRMVH_PCTBL1")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctbl2)
                    .HasColumnName("FCRMVH_PCTBL2")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctbl3)
                    .HasColumnName("FCRMVH_PCTBL3")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctdes)
                    .HasColumnName("FCRMVH_PCTDES")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctdi1)
                    .HasColumnName("FCRMVH_PCTDI1")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctdi2)
                    .HasColumnName("FCRMVH_PCTDI2")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctdi3)
                    .HasColumnName("FCRMVH_PCTDI3")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctdm1)
                    .HasColumnName("FCRMVH_PCTDM1")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctdm2)
                    .HasColumnName("FCRMVH_PCTDM2")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctdm3)
                    .HasColumnName("FCRMVH_PCTDM3")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Pctfin)
                    .HasColumnName("FCRMVH_PCTFIN")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Sector)
                    .HasColumnName("FCRMVH_SECTOR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Sectra)
                    .HasColumnName("FCRMVH_SECTRA")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Subcue)
                    .HasColumnName("FCRMVH_SUBCUE")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Subori)
                    .HasColumnName("FCRMVH_SUBORI")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Sucfis)
                    .HasColumnName("FCRMVH_SUCFIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Sucurs)
                    .HasColumnName("FCRMVH_SUCURS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Tasain)
                    .HasColumnName("FCRMVH_TASAIN")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvh_Telefn)
                    .HasColumnName("FCRMVH_TELEFN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Textos)
                    .HasColumnName("FCRMVH_TEXTOS")
                    .HasColumnType("text");

                entity.Property(e => e.Fcrmvh_Tipdoc)
                    .HasColumnName("FCRMVH_TIPDOC")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Tipexp)
                    .HasColumnName("FCRMVH_TIPEXP")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Tipopr)
                    .HasColumnName("FCRMVH_TIPOPR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Tracod)
                    .HasColumnName("FCRMVH_TRACOD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Trandr)
                    .HasColumnName("FCRMVH_TRANDR")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Transp)
                    .HasColumnName("FCRMVH_TRANSP")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Trcuit)
                    .HasColumnName("FCRMVH_TRCUIT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Ultopr)
                    .HasColumnName("FCRMVH_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvh_Userid)
                    .HasColumnName("FCRMVH_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Usraut)
                    .HasColumnName("FCRMVH_USRAUT")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvh_Vnddor)
                    .IsRequired()
                    .HasColumnName("FCRMVH_VNDDOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Sar_Fcrmvh_Envmai)
                    .HasColumnName("SAR_FCRMVH_ENVMAI")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sar_Fcrmvh_Nickml)
                    .HasColumnName("SAR_FCRMVH_NICKML")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Sar_Fcrmvh_Tranum)
                    .HasColumnName("SAR_FCRMVH_TRANUM")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Sar_Fcrmvh_Traurl)
                    .HasColumnName("SAR_FCRMVH_TRAURL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sar_Fcrmvh_Userml)
                    .HasColumnName("SAR_FCRMVH_USERML")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvh_Acopio)
                    .HasColumnName("USR_FCRMVH_ACOPIO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usr_Fcrmvh_Autcom).HasColumnName("USR_FCRMVH_AUTCOM");

                entity.Property(e => e.Usr_Fcrmvh_Consig)
                    .HasColumnName("USR_FCRMVH_CONSIG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usr_Fcrmvh_Estaut).HasColumnName("USR_FCRMVH_ESTAUT");

                entity.Property(e => e.Usr_Fcrmvh_Facant)
                    .HasColumnName("USR_FCRMVH_FACANT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usr_Fcrmvh_Fecaut)
                    .HasColumnName("USR_FCRMVH_FECAUT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Usr_Fcrmvh_Logist)
                    .HasColumnName("USR_FCRMVH_LOGIST")
                    .HasColumnType("text");

                entity.Property(e => e.Usr_Fcrmvh_Muedon)
                    .HasColumnName("USR_FCRMVH_MUEDON")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usr_Fcrmvh_Nrolem).HasColumnName("USR_FCRMVH_NROLEM");

                entity.Property(e => e.Usr_Fcrmvh_Nrorem)
                    .HasColumnName("USR_FCRMVH_NROREM")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvh_Obscom)
                    .HasColumnName("USR_FCRMVH_OBSCOM")
                    .HasColumnType("text");

                entity.Property(e => e.Usr_Fcrmvh_Direml)
                    .HasColumnName("USR_FCRMVH_DIREML")
                    .HasMaxLength(255)
                    .IsUnicode(false);


                entity.Property(e => e.Usr_Fcrmvh_Retira)
                    .HasColumnName("USR_FCRMVH_RETIRA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usr_Fcrmvh_Trared)
                    .HasColumnName("USR_FCRMVH_TRARED")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvh_Usrcom)
                    .HasColumnName("USR_FCRMVH_USRCOM")
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fcrmvi>(entity =>
            {
                entity.HasKey(e => new { e.Fcrmvi_Codemp, e.Fcrmvi_Modfor, e.Fcrmvi_Codfor, e.Fcrmvi_Nrofor, e.Fcrmvi_Nroitm, e.Fcrmvi_Nivexp, e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl })
                    .HasName("PK_FCRMVI_CONSTRAINT");

                entity.ToTable("FCRMVI");

                entity.HasIndex(e => new { e.Fcrmvi_Cantid, e.Fcrmvi_Tippro, e.Fcrmvi_Artcod })
                    .HasName("USR_bi01");

                entity.HasIndex(e => new { e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl })
                    .HasName("T_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl })
                    .HasName("S_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Tippro, e.Fcrmvi_Artcod })
                    .HasName("W_ST_STRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Codemp, e.Fcrmvi_Modfor, e.Fcrmvi_Codfor, e.Fcrmvi_Nrofor })
                    .HasName("W_FC_FCRMVH1UPD");

                entity.HasIndex(e => new { e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Deposi, e.Fcrmvi_Sector, e.Fcrmvi_Fchent, e.Fcrmvi_Cantst })
                    .HasName("T_GR_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Nroapl, e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl, e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Cantid })
                    .HasName("W_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Nivexp, e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Precio, e.Fcrmvi_Cantid, e.Fcrmvi_Pctbfn })
                    .HasName("W_GR_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Precio, e.Fcrmvi_Cantid, e.Fcrmvi_Pctbfn, e.Fcrmvi_Cntbon, e.Fcrmvi_Codemp, e.Fcrmvi_Modfor, e.Fcrmvi_Nrofor, e.Fcrmvi_Codapl })
                    .HasName("USR_001");

                entity.HasIndex(e => new { e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Tipori, e.Fcrmvi_Artori, e.Fcrmvi_Cantid, e.Fcrmvi_Pctbfn, e.Fcrmvi_Empini, e.Fcrmvi_Nroini, e.Fcrmvi_Modini, e.Fcrmvi_Codini })
                    .HasName("USR_pedfab");

                entity.HasIndex(e => new { e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Deposi, e.Fcrmvi_Sector, e.Fcrmvi_Precio, e.Fcrmvi_Cantid, e.Fcrmvi_Fchent, e.Fcrmvi_Pctbfn, e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Fchhas })
                    .HasName("USR_op01");

                entity.HasIndex(e => new { e.Fcrmvi_Fchent, e.Fcrmvi_Fchhas, e.Fcrmvi_Modfor, e.Fcrmvi_Codfor, e.Fcrmvi_Nrofor, e.Fcrmvi_Codemp, e.Fcrmvi_Nroitm, e.Fcrmvi_Nivexp, e.Fcrmvi_Empapl, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl })
                    .HasName("P_VT_MovPendCAE");

                entity.HasIndex(e => new { e.Fcrmvi_Tippro, e.Fcrmvi_Artcod, e.Fcrmvi_Tipcpt, e.Fcrmvi_Codcpt, e.Fcrmvi_Tipori, e.Fcrmvi_Artori, e.Fcrmvi_Precio, e.Fcrmvi_Cantid, e.Fcrmvi_Fchhas, e.Fcrmvi_Pctbfn, e.Fcrmvi_Cntbon, e.Fcrmvi_Codini, e.Fcrmvi_Nroini, e.Usr_Fcrmvi_Vnddor, e.Fcrmvi_Codemp, e.Fcrmvi_Nivexp })
                    .HasName("USR_op02");

                entity.Property(e => e.Fcrmvi_Codemp)
                    .HasColumnName("FCRMVI_CODEMP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Modfor)
                    .HasColumnName("FCRMVI_MODFOR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Codfor)
                    .HasColumnName("FCRMVI_CODFOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Nrofor).HasColumnName("FCRMVI_NROFOR");

                entity.Property(e => e.Fcrmvi_Nroitm).HasColumnName("FCRMVI_NROITM");

                entity.Property(e => e.Fcrmvi_Nivexp)
                    .HasColumnName("FCRMVI_NIVEXP")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Empapl)
                    .HasColumnName("FCRMVI_EMPAPL")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Modapl)
                    .HasColumnName("FCRMVI_MODAPL")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Codapl)
                    .HasColumnName("FCRMVI_CODAPL")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Nroapl).HasColumnName("FCRMVI_NROAPL");

                entity.Property(e => e.Fcrmvi_Itmapl).HasColumnName("FCRMVI_ITMAPL");

                entity.Property(e => e.Fcrmvi_Expapl)
                    .HasColumnName("FCRMVI_EXPAPL")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Aerpue)
                    .HasColumnName("FCRMVI_AERPUE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Artcod)
                    .IsRequired()
                    .HasColumnName("FCRMVI_ARTCOD")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Artequ)
                    .HasColumnName("FCRMVI_ARTEQU")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Artori)
                    .HasColumnName("FCRMVI_ARTORI")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Cambio)
                    .HasColumnName("FCRMVI_CAMBIO")
                    .HasColumnType("numeric(20, 8)");

                entity.Property(e => e.Fcrmvi_Cancel)
                    .HasColumnName("FCRMVI_CANCEL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Cantid)
                    .HasColumnName("FCRMVI_CANTID")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cantst)
                    .HasColumnName("FCRMVI_CANTST")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Ccdapl)
                    .HasColumnName("FCRMVI_CCDAPL")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Cntalt)
                    .HasColumnName("FCRMVI_CNTALT")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cntant)
                    .HasColumnName("FCRMVI_CNTANT")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cntbon)
                    .HasColumnName("FCRMVI_CNTBON")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cntcon)
                    .HasColumnName("FCRMVI_CNTCON")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cntfac)
                    .HasColumnName("FCRMVI_CNTFAC")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cntori)
                    .HasColumnName("FCRMVI_CNTORI")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cntpen)
                    .HasColumnName("FCRMVI_CNTPEN")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cntsec)
                    .HasColumnName("FCRMVI_CNTSEC")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cntuni)
                    .HasColumnName("FCRMVI_CNTUNI")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Cntvar)
                    .HasColumnName("FCRMVI_CNTVAR")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Fcrmvi_Codcpt)
                    .HasColumnName("FCRMVI_CODCPT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Codgan)
                    .HasColumnName("FCRMVI_CODGAN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Codini)
                    .HasColumnName("FCRMVI_CODINI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Codopr)
                    .HasColumnName("FCRMVI_CODOPR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Codori)
                    .HasColumnName("FCRMVI_CODORI")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Codost)
                    .HasColumnName("FCRMVI_CODOST")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Codpro)
                    .HasColumnName("FCRMVI_CODPRO")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Codtar)
                    .HasColumnName("FCRMVI_CODTAR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Coflis)
                    .HasColumnName("FCRMVI_COFLIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Cuenta)
                    .HasColumnName("FCRMVI_CUENTA")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Debaja)
                    .HasColumnName("FCRMVI_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Deposi)
                    .HasColumnName("FCRMVI_DEPOSI")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Deptra)
                    .HasColumnName("FCRMVI_DEPTRA")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Empgan)
                    .HasColumnName("FCRMVI_EMPGAN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Empini)
                    .HasColumnName("FCRMVI_EMPINI")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Empori)
                    .HasColumnName("FCRMVI_EMPORI")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Empost)
                    .HasColumnName("FCRMVI_EMPOST")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Envase)
                    .HasColumnName("FCRMVI_ENVASE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Expori)
                    .HasColumnName("FCRMVI_EXPORI")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Expost)
                    .HasColumnName("FCRMVI_EXPOST")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Facalt)
                    .HasColumnName("FCRMVI_FACALT")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.Fcrmvi_Faccon)
                    .HasColumnName("FCRMVI_FACCON")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.Fcrmvi_Facfac)
                    .HasColumnName("FCRMVI_FACFAC")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.Fcrmvi_Facsec)
                    .HasColumnName("FCRMVI_FACSEC")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.Fcrmvi_Factor)
                    .HasColumnName("FCRMVI_FACTOR")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.Fcrmvi_Fchent)
                    .HasColumnName("FCRMVI_FCHENT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvi_Fchhas)
                    .HasColumnName("FCRMVI_FCHHAS")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvi_Fecalt)
                    .HasColumnName("FCRMVI_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fcrmvi_Fecmod)
                    .HasColumnName("FCRMVI_FECMOD")
                    .HasColumnType("datetime");


                entity.Property(e => e.Fcrmvi_Itmini).HasColumnName("FCRMVI_ITMINI");

                entity.Property(e => e.Fcrmvi_Itmori).HasColumnName("FCRMVI_ITMORI");

                entity.Property(e => e.Fcrmvi_Itmost).HasColumnName("FCRMVI_ITMOST");

                entity.Property(e => e.Fcrmvi_Mcdapl)
                    .HasColumnName("FCRMVI_MCDAPL")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Modcpt)
                    .HasColumnName("FCRMVI_MODCPT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Modgan)
                    .HasColumnName("FCRMVI_MODGAN")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Modini)
                    .HasColumnName("FCRMVI_MODINI")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Modori)
                    .HasColumnName("FCRMVI_MODORI")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Modost)
                    .HasColumnName("FCRMVI_MODOST")
                    .HasMaxLength(2)
                    .IsUnicode(false);


                entity.Property(e => e.Fcrmvi_Natrib)
                    .HasColumnName("FCRMVI_NATRIB")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Ncanpn)
                    .HasColumnName("FCRMVI_NCANPN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Ncnpna)
                    .HasColumnName("FCRMVI_NCNPNA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Ndespa)
                    .HasColumnName("FCRMVI_NDESPA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Nestan)
                    .HasColumnName("FCRMVI_NESTAN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Newpre)
                    .HasColumnName("FCRMVI_NEWPRE")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.Fcrmvi_Nfecha)
                    .HasColumnName("FCRMVI_NFECHA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Ngenpn)
                    .HasColumnName("FCRMVI_NGENPN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Ngenst)
                    .HasColumnName("FCRMVI_NGENST")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Nivini)
                    .HasColumnName("FCRMVI_NIVINI")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Notros)
                    .HasColumnName("FCRMVI_NOTROS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Nrocta)
                    .HasColumnName("FCRMVI_NROCTA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Nrogan).HasColumnName("FCRMVI_NROGAN");

                entity.Property(e => e.Fcrmvi_Nroini).HasColumnName("FCRMVI_NROINI");

                entity.Property(e => e.Fcrmvi_Nroori).HasColumnName("FCRMVI_NROORI");

                entity.Property(e => e.Fcrmvi_Nroost).HasColumnName("FCRMVI_NROOST");

                entity.Property(e => e.Fcrmvi_Nrosub)
                    .HasColumnName("FCRMVI_NROSUB")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Nserie)
                    .HasColumnName("FCRMVI_NSERIE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Nubica)
                    .HasColumnName("FCRMVI_NUBICA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Oalias)
                    .HasColumnName("FCRMVI_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Oldpre)
                    .HasColumnName("FCRMVI_OLDPRE")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.Fcrmvi_Pctbf1)
                    .HasColumnName("FCRMVI_PCTBF1")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctbf2)
                    .HasColumnName("FCRMVI_PCTBF2")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctbf3)
                    .HasColumnName("FCRMVI_PCTBF3")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctbf4)
                    .HasColumnName("FCRMVI_PCTBF4")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctbf5)
                    .HasColumnName("FCRMVI_PCTBF5")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctbf6)
                    .HasColumnName("FCRMVI_PCTBF6")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctbf7)
                    .HasColumnName("FCRMVI_PCTBF7")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctbf8)
                    .HasColumnName("FCRMVI_PCTBF8")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctbf9)
                    .HasColumnName("FCRMVI_PCTBF9")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctbfn)
                    .HasColumnName("FCRMVI_PCTBFN")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Pctcom)
                    .HasColumnName("FCRMVI_PCTCOM")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Porant)
                    .HasColumnName("FCRMVI_PORANT")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Fcrmvi_Precio)
                    .HasColumnName("FCRMVI_PRECIO")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.Fcrmvi_Preext)
                    .HasColumnName("FCRMVI_PREEXT")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.Fcrmvi_Prenac)
                    .HasColumnName("FCRMVI_PRENAC")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.Fcrmvi_Presec)
                    .HasColumnName("FCRMVI_PRESEC")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.Fcrmvi_Preuss)
                    .HasColumnName("FCRMVI_PREUSS")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.Fcrmvi_Sector)
                    .HasColumnName("FCRMVI_SECTOR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Sectra)
                    .HasColumnName("FCRMVI_SECTRA")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Sucurs)
                    .HasColumnName("FCRMVI_SUCURS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Tatrib)
                    .HasColumnName("FCRMVI_TATRIB")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Tdespa)
                    .HasColumnName("FCRMVI_TDESPA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Tenvas)
                    .HasColumnName("FCRMVI_TENVAS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Testan)
                    .HasColumnName("FCRMVI_TESTAN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Textos)
                    .HasColumnName("FCRMVI_TEXTOS")
                    .HasColumnType("text");

                entity.Property(e => e.Fcrmvi_Tfecha)
                    .HasColumnName("FCRMVI_TFECHA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Tipcpt)
                    .HasColumnName("FCRMVI_TIPCPT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Tipopr)
                    .HasColumnName("FCRMVI_TIPOPR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Tipori)
                    .HasColumnName("FCRMVI_TIPORI")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Tippro)
                    .IsRequired()
                    .HasColumnName("FCRMVI_TIPPRO")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Tipuni)
                    .HasColumnName("FCRMVI_TIPUNI")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Totlin)
                    .HasColumnName("FCRMVI_TOTLIN")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Fcrmvi_Totros)
                    .HasColumnName("FCRMVI_TOTROS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Tserie)
                    .HasColumnName("FCRMVI_TSERIE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Tubica)
                    .HasColumnName("FCRMVI_TUBICA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Ultopr)
                    .HasColumnName("FCRMVI_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcrmvi_Unialt)
                    .HasColumnName("FCRMVI_UNIALT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Unicon)
                    .HasColumnName("FCRMVI_UNICON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Unifac)
                    .HasColumnName("FCRMVI_UNIFAC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Unimed)
                    .HasColumnName("FCRMVI_UNIMED")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Unisec)
                    .HasColumnName("FCRMVI_UNISEC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fcrmvi_Userid)
                    .HasColumnName("FCRMVI_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvi_Acopio)
                    .HasColumnName("USR_FCRMVI_ACOPIO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usr_Fcrmvi_Bultos).HasColumnName("USR_FCRMVI_BULTOS");

                entity.Property(e => e.Usr_Fcrmvi_Cdent1)
                    .HasColumnName("USR_FCRMVI_CDENT1")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvi_Cndpag)
                    .HasColumnName("USR_FCRMVI_CNDPAG")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvi_Codzon)
                    .HasColumnName("USR_FCRMVI_CODZON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvi_Diren2)
                    .HasColumnName("USR_FCRMVI_DIREN2")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvi_Dirent)
                    .HasColumnName("USR_FCRMVI_DIRENT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvi_Facant)
                    .HasColumnName("USR_FCRMVI_FACANT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usr_Fcrmvi_Jurisd)
                    .HasColumnName("USR_FCRMVI_JURISD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvi_Palets).HasColumnName("USR_FCRMVI_PALETS");

                entity.Property(e => e.Usr_Fcrmvi_Salsto)
                    .HasColumnName("USR_FCRMVI_SALSTO")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Usr_Fcrmvi_Stdisp)
                    .HasColumnName("USR_FCRMVI_STDISP")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Usr_Fcrmvi_Totbon)
                    .HasColumnName("USR_FCRMVI_TOTBON")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.Usr_Fcrmvi_Trared)
                    .HasColumnName("USR_FCRMVI_TRARED")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Usr_Fcrmvi_Vnddor)
                    .HasColumnName("USR_FCRMVI_VNDDOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
