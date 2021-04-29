using APISoftlandAnclaflex.Models;
using APISoftlandAnclaflex.Repositories;
using APISoftlandAnclaflex.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Services
{
    internal interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    internal class PostearDatosEnPortalWebService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly ILogger _logger;
        private static readonly HttpClient client = new HttpClient();
        public IMapper _mapper { get; }
        public IConfiguration _configuration { get; }
        public BonificacionesRepository BonificacionesRepository { get; }
        public ClientesRepository ClientesRepository { get; }
        public ClienteDireccionesDeEntregaRepository ClientesDireccionesEntregaRepository { get; }
        public ListasDePrecioRepository ListasDePrecioRepository { get; }
        public ProductosRepository ProductosRepository { get; }
        public ProvinciasRepository ProvinciasRepository { get; }
        public TransportistasRedespachoRepository TransportistasRedespachoRepository { get; }
        public UsuariosRepository UsuariosRepository { get; }
        public VendedoresRepository VendedoresRepository { get; }

        public PostearDatosEnPortalWebService(Serilog.ILogger logger,IMapper mapper, IConfiguration configuration,
                                              BonificacionesRepository _bonificacionesRepository,
                                              ClientesRepository _clientesRepository,
                                              ClienteDireccionesDeEntregaRepository _clientesDireccionesEntregaRepository,
                                              ListasDePrecioRepository _listasDePrecioRepository,
                                              ProductosRepository _productosRepository,
                                              ProvinciasRepository _provinciasRepository,
                                              TransportistasRedespachoRepository _transportistasRedespachoRepository,
                                              UsuariosRepository _usuariosRepository,
                                              VendedoresRepository _vendedoresRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
            BonificacionesRepository = _bonificacionesRepository;
            ClientesRepository = _clientesRepository;
            ClientesDireccionesEntregaRepository = _clientesDireccionesEntregaRepository;
            ListasDePrecioRepository = _listasDePrecioRepository;
            ProductosRepository = _productosRepository;
            ProvinciasRepository = _provinciasRepository;
            TransportistasRedespachoRepository = _transportistasRedespachoRepository;
            UsuariosRepository = _usuariosRepository;
            VendedoresRepository = _vendedoresRepository;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;
                _logger.Information(
                    $"Scoped Processing Service is working. Count: {0}", executionCount);

                await PostearRecurso<Provincia>(ProvinciasRepository, "GRTJUR", "Provincia");
                await PostearRecurso<Transportistasredespacho>(TransportistasRedespachoRepository, "GRTTRA", "TransportistaRedespacho");
                await PostearRecurso<Vendedores>(VendedoresRepository, "VTTVND", "Vendedor");

                await PostearRecurso<Producto>(ProductosRepository, "STMPDH", "Producto");
                await PostearRecurso<Listasdeprecio>(ListasDePrecioRepository, "STTPRE", "ListasDePrecio");
                
                await PostearRecurso<Cliente>(ClientesRepository, "VTMCLH", "Cliente");
                await PostearRecurso<Clientesdireccionesentrega>(ClientesDireccionesEntregaRepository, "VTTENT", "ClienteDireccionesEntrega");

                await PostearRecurso<Usuario>(UsuariosRepository, "USR_PWTUSH", "Usuario");
                await PostearRecurso<Bonificacion>(BonificacionesRepository, "FCTBGI", "Bonificacion");

                await Task.Delay(10000, stoppingToken);
            }
        }

        private async Task PostearRecurso<T>(IRepository<T> repository, string objeto, string resourcePath)
        {
            IEnumerable<T> data = await repository.GetForPortalWeb(objeto);
            
            Type type = typeof(T);
            System.Reflection.PropertyInfo propiedadRowId = type.GetProperty("RowID");
            System.Reflection.PropertyInfo propiedadTipoOperacion = type.GetProperty("Sfl_TableOperation");
            System.Reflection.PropertyInfo propiedadId = type.GetProperty("Id");

            foreach (T item in data)
            {
                int rowId = (int)propiedadRowId.GetValue(item);
                string tipoOperacion = (string)propiedadTipoOperacion.GetValue(item);
                string Id = (string)propiedadId.GetValue(item);

                string stringRequest = JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true });
                _logger.Information($"Se envia recurso { stringRequest }");
                HttpResponseMessage stringTask = new HttpResponseMessage();
                object stream = new object();
                switch (tipoOperacion)
                {
                    case "INSERT":
                        stringTask = await client.PostAsync($"{_configuration["HostPortalWeb:BasePath"]}/{resourcePath}", new StringContent(stringRequest, Encoding.UTF8, "application/json"));
                        stream = await stringTask.Content.ReadAsStreamAsync();
                        break;
                    case "UPDATE":
                        stringTask = await client.PutAsync($"{_configuration["HostPortalWeb:BasePath"]}/{resourcePath}/{Id}", new StringContent(stringRequest, Encoding.UTF8, "application/json"));
                        stream = await stringTask.Content.ReadAsStreamAsync();
                        break;
                    case "DELETE":
                        System.Reflection.PropertyInfo propiedadActivo = type.GetProperty("Activo");
                        propiedadActivo.SetValue(item, 0);
                        stringRequest = JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true });
                        stringTask = await client.PutAsync($"{_configuration["HostPortalWeb:BasePath"]}/{resourcePath}", new StringContent(stringRequest, Encoding.UTF8, "application/json"));
                        stream = await stringTask.Content.ReadAsStreamAsync();
                        break;
                    default:
                        break;
                }
                
                

                if (stringTask.IsSuccessStatusCode)
                {
                    try
                    {
                        
                        await repository.ActualizaRecursoTransferido(rowId,"S",objeto);
                        _logger.Information("Recurso generado con exito");
                    }
                    catch (Exception ex)
                    {
                        _logger.Fatal($"Error al actualizar recurso como transferido: {ex.Message}");
                    }

                }
                else
                {
                    try
                    {

                        await repository.ActualizaRecursoTransferido(rowId, "E", objeto);
                    }
                    catch (Exception ex)
                    {
                        _logger.Fatal($"Error al actualizar recurso como no transferido: {ex.Message}");
                    }
                    
                    try
                    {
                        var content = await JsonSerializer.DeserializeAsync<PortalWebResponse>((Stream)stream);
                        _logger.Fatal($"Error al postear recurso en {resourcePath}: {content}");
                    }
                    catch
                    {
                        _logger.Fatal($"Error al postear recurso en {resourcePath}: no se pudieron obtener detalles del error");
                    }
                    
                }
            }
            
        }
    }
}
