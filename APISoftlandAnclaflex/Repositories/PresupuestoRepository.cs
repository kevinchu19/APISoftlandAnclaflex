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
    public class PresupuestoRepository : RepositoryBase<string>
    {
        public IOEObject oFCRMVH { get; set; }
        public Translate Translate { get; }

        public PresupuestoRepository(ANCLAFContext context, Serilog.ILogger logger, IConfiguration configuration,Translate translate) :
            base(context, configuration, logger)
        {
            Translate = translate;
        }

        public PresupuestoResponse PostPresupuesto(Fcrmvh _presupuesto, string _tipoOperacion, bool pagoEfectivo)
        {
            string companyName = pagoEfectivo ? Configuration["CompanyNameEfectivo"] : Configuration["CompanyName"];
            
            FC_RR_FCRMVH oFCRMVH = new FC_RR_FCRMVH("admin", Configuration["PasswordAdmin"],companyName, Configuration, Logger);

            oFCRMVH.InstancioObjeto(_tipoOperacion, "0100", "0100", "PRW");

            Type typePresupuesto = _presupuesto.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typePresupuesto.GetProperties();
                
            oFCRMVH.AsignoaTM<Fcrmvh>("FCRMVH", _presupuesto, 1);
                
            foreach (Fcrmvi item in _presupuesto.Items)
            {
                oFCRMVH.AsignoaTM<Fcrmvi>("FCRMVI", item, 2);
            }

            Save PerformedOperation = oFCRMVH.Save();

            bool result = PerformedOperation.Result;
            string mensajeError = PerformedOperation.errorMessage;


            oFCRMVH.CloseObjectInstance();

            if (result == false)
            {
                return new PresupuestoResponse("Bad Request", mensajeError);
            }

            return new PresupuestoResponse("Presupuesto Generado Exitosamente");
        }
    }
}
