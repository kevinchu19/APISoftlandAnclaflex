using APISoftlandAnclaflex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Helpers
{
    public class PedidoResponse : BaseResponse<PedidoDTO>
    {

        public PedidoResponse(string titulo) : base(titulo) { }
        public PedidoResponse(string titulo, PedidoDTO resource) : base(titulo, resource) { }
        public PedidoResponse(string titulo, string message) : base(titulo, message) { }


    }
}
