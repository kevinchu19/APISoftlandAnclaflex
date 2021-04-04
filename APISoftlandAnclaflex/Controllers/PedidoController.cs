using System;
using System.Collections.Generic;
using System.Linq;
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

            foreach (PedidoDTO pedido in pedidos)
            {
                PedidoResponse result = _repository.PostPedido(_mapper.Map<PedidoDTO, Fcrmvh>(pedido), "RUN_FOR_SCRIPT");
                if (result.Estado == 200)
                {
                    response.Add(new PedidoResponse(result.Titulo, pedido));
                }
                else
                {
                    response.Add(new PedidoResponse(result.Titulo, result.Mensaje));
                }
                
            }

            return Ok(response);
        }
    }
}
