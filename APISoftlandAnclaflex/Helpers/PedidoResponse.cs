using APISoftlandAnclaflex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Helpers
{
    public class PresupuestoResponse : BaseResponse<PresupuestoDTO>
    {

        public PresupuestoResponse(string titulo) : base(titulo) { }
        public PresupuestoResponse(string titulo, PresupuestoDTO resource) : base(titulo, resource) { }
        public PresupuestoResponse(string titulo, string message) : base(titulo, message) { }


    }
}
