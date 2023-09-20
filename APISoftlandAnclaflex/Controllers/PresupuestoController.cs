using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using APISoftlandAnclaflex.Entities;
using APISoftlandAnclaflex.Helpers;
using APISoftlandAnclaflex.Models;
using APISoftlandAnclaflex.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APISoftlandAnclaflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        public PedidoRepository _repository { get; }
        public IMapper _mapper { get; }

        private readonly Serilog.ILogger _logger;

        public PedidoController(Serilog.ILogger logger, PedidoRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        

        [HttpPost]
        public ActionResult<IEnumerable<PedidoResponse>> PostPedido([FromBody] IEnumerable<PedidoDTO> pedidos)
        {
            List<PedidoResponse> response = new List<PedidoResponse>();

            _logger.Information($"Lote de pedidos recibidos:{ JsonSerializer.Serialize(pedidos,new JsonSerializerOptions { WriteIndented=true,})}");

            foreach (PedidoDTO pedido in pedidos)
            {
                _logger.Information($"Procesando pedido {pedido.Id}");

                PedidoResponse result = _repository.PostPedido(_mapper.Map<PedidoDTO, Fcrmvh>(pedido), "RUN_FOR_SCRIPT", pedido.PagoEnEfectivo==1?true:false);
                if (result.Estado == 200)
                {
                    _logger.Information($"Pedido {pedido.Id} generado exitosamente");
                    response.Add(new PedidoResponse(result.Titulo, pedido));
                }
                else
                {
                    _logger.Error($"Pedido {pedido.Id} no generado por un error: {result.Mensaje}");
                    response.Add(new PedidoResponse(result.Titulo, result.Mensaje));
                }
                
            }

            if (response.Any(item => item.Estado != 200))
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
