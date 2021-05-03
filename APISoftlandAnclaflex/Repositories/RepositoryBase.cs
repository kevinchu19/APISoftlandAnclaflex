using APISoftlandAnclaflex.Entities;
using APISoftlandAnclaflex.Models;
using APISoftlandAnclaflex.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Repositories
{
    public class RepositoryBase<TResponse>:IRepository<TResponse>
    {

        public ANCLAFContext Context { get; }
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        public RepositoryBase(ANCLAFContext context, IConfiguration configuration, Serilog.ILogger logger)
        {
            Context = context;
            Configuration = configuration;
            Logger = logger;
        }

        public async Task<ICollection<TResponse>> GetForPortalWeb(string objeto)
        {
            List<TResponse> response = new List<TResponse>();


            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand($"ALM_{objeto}GetForPortalWeb", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue<TResponse>(reader));
                        }
                    }
                }
            }

            return response;

        }

        public async Task ActualizaRecursoTransferido(int id, string transferido,string objeto)
        {
            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand($"UPDATE {objeto}log SET USR_TRANPW = '{transferido}' WHERE ROWID = {id}", sql))
                {   
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        private TResponse MapToValue<TResponse>(SqlDataReader reader) 
        {
            TResponse respuesta = (TResponse)Activator.CreateInstance(typeof(TResponse), new object[] { });
            Type typeResponse = typeof(TResponse);
            System.Reflection.PropertyInfo[] listaPropiedades = typeResponse.GetProperties();

            for (int i = 0; i < reader.FieldCount-1; i++)
            {    
                switch (listaPropiedades[i].Name )
                {
                    case "Activo":
                    listaPropiedades[i].SetValue(respuesta, (string)reader["DeBaja"]=="S"?0:1);
                        break;
                    default:
                        if (reader[listaPropiedades[i].Name] != DBNull.Value)
                        {
                            listaPropiedades[i].SetValue(respuesta, reader[listaPropiedades[i].Name]);
                        }
                        break;
                }
            }

            return (TResponse)respuesta;
        }

        
    }

}
