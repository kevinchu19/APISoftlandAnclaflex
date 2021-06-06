using APISoftlandAnclaflex.Entities;
using APISoftlandAnclaflex.Helpers;
using APISoftlandAnclaflex.Models;
using APISoftlandAnclaflex.OE;
using APISoftlandAnclaflex.OE.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Repositories
{
    public class PedidoRepository : RepositoryBase<string>
    {
        public IOEObject oFCRMVH { get; set; }
        public Translate Translate { get; }

        public PedidoRepository(ANCLAFContext context, Serilog.ILogger logger, IConfiguration configuration,Translate translate) :
            base(context, configuration, logger)
        {
            Translate = translate;
        }

        public PedidoResponse PostPedido(Fcrmvh _pedido, string _tipoOperacion, bool pagoEfectivo)
        {
            string companyName = pagoEfectivo ? Configuration["CompanyNameEfectivo"] : Configuration["CompanyName"];
            
            FC_RR_FCRMVH oFCRMVH = new FC_RR_FCRMVH("admin", Configuration["PasswordAdmin"],companyName, Configuration, Logger);

            oFCRMVH.InstancioObjeto(_tipoOperacion);

            Type typePedido = _pedido.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typePedido.GetProperties();
                
            oFCRMVH.AsignoaTM<Fcrmvh>("FCRMVH", _pedido, 1);
                
            foreach (Fcrmvi item in _pedido.Items)
            {
                oFCRMVH.AsignoaTM<Fcrmvi>("FCRMVI", item, 2);
            }

            Save PerformedOperation = oFCRMVH.Save();

            bool result = PerformedOperation.Result;
            string mensajeError = PerformedOperation.errorMessage;


            oFCRMVH.CloseObjectInstance();

            if (result == false)
            {
                return new PedidoResponse("Bad Request", mensajeError);
            }

            return new PedidoResponse("Pedido Generado Exitosamente");
        }
    }
}
