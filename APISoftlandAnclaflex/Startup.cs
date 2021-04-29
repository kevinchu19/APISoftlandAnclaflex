using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISoftlandAnclaflex.Entities;
using APISoftlandAnclaflex.Helpers;
using APISoftlandAnclaflex.MapperHelp;
using APISoftlandAnclaflex.Models;
using APISoftlandAnclaflex.OE;
using APISoftlandAnclaflex.OE.Interfaces;
using APISoftlandAnclaflex.Repositories;
using APISoftlandAnclaflex.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace APISoftlandAnclaflex
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<ConsumeScopedServiceHostedService>();
            services.AddScoped<IScopedProcessingService, PostearDatosEnPortalWebService>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()//.WithOrigins("http://localhost:4200", "http://localhost:44349")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            services.AddScoped<PedidoRepository>();

            services.AddScoped<BonificacionesRepository>();
            services.AddScoped<ClienteDireccionesDeEntregaRepository>();
            services.AddScoped<ClientesRepository>();
            services.AddScoped<ListasDePrecioRepository>();
            services.AddScoped<ProductosRepository>();
            services.AddScoped<ProvinciasRepository>();
            services.AddScoped<TransportistasRedespachoRepository>();
            services.AddScoped<UsuariosRepository>();
            services.AddScoped<VendedoresRepository>();


            services.AddSingleton<Translate>();

            services.AddTransient<IOEObject, FC_RR_FCRMVH>(provider =>
                new FC_RR_FCRMVH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration));


            services.AddMvc(Options =>
            {
                Options.Filters.Add(typeof(FiltroDeExcepcion));
            }).
               SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<ANCLAFContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")).EnableSensitiveDataLogging());
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));


            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<PedidoDTO, Fcrmvh>()
                .ForMember(dest => dest.Virt_Nroffc, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Fcrmvh_Nrocta, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.Fcrmvh_Cdent1, opt => opt.MapFrom(src => src.IdEntrega))
                .ForMember(dest => dest.Fcrmvh_Dirent, opt => opt.MapFrom(src => src.DireccionEntrega))
                .ForMember(dest => dest.Fcrmvh_Paient, opt => opt.MapFrom(src => src.PaisEntrega))
                .ForMember(dest => dest.Fcrmvh_Codent, opt => opt.MapFrom(src => src.CodigoPostalEntrega))
                .ForMember(dest => dest.Fcrmvh_Jurisd, opt => opt.MapFrom(src => src.ProvinciaEntrega))
                .ForMember(dest => dest.Fcrmvh_Codlis, opt => opt.MapFrom(src => src.ListaPrecios))
                .ForMember(dest => dest.Usr_Fcrmvh_Trared, opt => opt.MapFrom(src => src.TransportistaRedespacho))
                .ForMember(dest => dest.Fcrmvh_Textos, opt => opt.MapFrom(src => src.Observacion))
                .ForMember(dest => dest.Usr_Fcrmvh_Logist, opt => opt.MapFrom(src => src.ObservacionLogistica))
                .ForMember(dest => dest.Fcrmvh_Vnddor, opt => opt.MapFrom(src => src.IdVendedor))
                .ForMember(dest => dest.Fcrmvh_Telefn, opt => opt.MapFrom(src => src.Telefono))
                .ForMember(dest => dest.Usr_Fcrmvh_Direml, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Fcrmvh_Fchmov, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.Usr_Fcrmvh_Retira, opt => opt.MapFrom(src => src.RetiradeFabrica))
                //.ForMember(dest => dest.Usr_Fcrmvh_, opt => opt.MapFrom(src => src.EsBarrioCerrado))
                //.ForMember(dest => dest.Fcrmvh_Nrofor, opt => opt.MapFrom(src => src.FechaDeEntrega))
                //.ForMember(dest => dest.Fcrmvh_Nrofor, opt => opt.MapFrom(src => src.PagoEnEfectivo))
                .ReverseMap();

                configuration.CreateMap<PedidoItemsDTO, Fcrmvi>()
                .ForMember(dest => dest.Fcrmvi_Tipori, opt => opt.MapFrom<TipoProductoResolver>())
                .ForMember(dest => dest.Fcrmvi_Artori, opt => opt.MapFrom<CodigoProductoResolver>())
                .ForMember(dest => dest.Fcrmvi_Cantid, opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.Fcrmvi_Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Fcrmvi_Pctbf1, opt => opt.MapFrom(src => src.Bonificacion1))
                .ForMember(dest => dest.Fcrmvi_Pctbf2, opt => opt.MapFrom(src => src.Bonificacion2))
                .ForMember(dest => dest.Fcrmvi_Pctbf3, opt => opt.MapFrom(src => src.Bonificacion3))
                .ReverseMap();
        }
                , typeof(Startup));

            services.AddSingleton<Serilog.ILogger>(options =>
            {
                var connstring = Configuration["Serilog:SerilogConnectionString"];
                var tableName = Configuration["Serilog:TableName"];

                return new LoggerConfiguration()
                            .WriteTo
                            .MSSqlServer(
                                connectionString: connstring,
                                sinkOptions: new MSSqlServerSinkOptions { TableName = tableName, AutoCreateSqlTable = true },
                                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
                            .CreateLogger();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
