using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISoftlandAnclaflex.Helpers;
using APISoftlandAnclaflex.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APISoftlandAnclaflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {

        private readonly Serilog.ILogger _logger;

        public PedidoController(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IEnumerable<PedidoResponse>> PostPedido([FromBody] PedidoDTO pedido)
        {


            return new List<PedidoResponse>(); 
        }
    }
}
