using APISoftlandAnclaflex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Helpers
{
    public class PedidoResponse : BaseResponse<PedidoDTO>
    {

        public PedidoResponse(string titulo, int idOperacion) : base(titulo, idOperacion) { }
        public PedidoResponse(string titulo, int idOperacion, PedidoDTO resource) : base(titulo, idOperacion, resource) { }
        public PedidoResponse(string titulo, int idOperacion, string message) : base(titulo, idOperacion, message) { }


    }
}
