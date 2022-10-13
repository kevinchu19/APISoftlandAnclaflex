using APISoftlandAnclaflex.Entities;
using APISoftlandAnclaflex.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Repositories
{
    public class CuentaCorrienteRepository:RepositoryBase<CuentaCorriente>
    {
        public CuentaCorrienteRepository(ANCLAFContext context, IConfiguration configuration, Serilog.ILogger logger): 
            base(context, configuration, logger)
        {

        }

        public override async Task ActualizaComprobanteTransferido(CuentaCorriente comprobante, string transferido, string objeto)
        {
            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand($"UPDATE anclaf.dbo.{objeto} SET USR_TRANPW = '{transferido}' WHERE " +
                                                       $"VTRMVC_CODEMP = '{comprobante.Empresa}' AND " +
                                                       $"VTRMVC_MODFOR = 'VT' AND " +
                                                       $"VTRMVC_CODFOR= '{comprobante.Codigoformulario}' AND " + 
                                                       $"VTRMVC_NROFOR = {comprobante.Numeroformulario} AND " +
                                                       $"VTRMVC_EMPAPL = '{comprobante.Empresaaplicacion}' AND " +
                                                       $"VTRMVC_MODAPL = 'VT' AND " +
                                                       $"VTRMVC_CODAPL = '{comprobante.Formularioaplicacion}' AND " +
                                                       $"VTRMVC_NROAPL = {comprobante.Numeroformularioaplicacion} AND " +
                                                       $"VTRMVC_CUOTAS= {comprobante.Cuota} ", sql))
                {
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
