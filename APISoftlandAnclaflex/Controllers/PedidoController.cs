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
    public class PresupuestoController : ControllerBase
    {
        public PresupuestoRepository _repository { get; }
        public IMapper _mapper { get; }

        private readonly Serilog.ILogger _logger;

        public PresupuestoController(Serilog.ILogger logger, PresupuestoRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        

        [HttpPost]
        public ActionResult<IEnumerable<PresupuestoResponse>> PostPresupuesto([FromBody] IEnumerable<PresupuestoDTO> presupuestos)
        {
            List<PresupuestoResponse> response = new List<PresupuestoResponse>();

            _logger.Information($"Lote de pedidos recibidos:{ JsonSerializer.Serialize(presupuestos,new JsonSerializerOptions { WriteIndented=true,})}");

            foreach (PresupuestoDTO presupuesto in presupuestos)
            {
                _logger.Information($"Procesando presupuesto {presupuesto.Id}");

                PresupuestoResponse result = _repository.PostPresupuesto(_mapper.Map<PresupuestoDTO, Fcrmvh>(presupuesto), "RUN_FOR_SCRIPT", presupuesto.PagoEnEfectivo==1?true:false);
                if (result.Estado == 200)
                {
                    _logger.Information($"Presupuesto {presupuesto.Id} generado exitosamente");
                    response.Add(new PresupuestoResponse(result.Titulo, presupuesto));
                }
                else
                {
                    _logger.Error($"Presupuesto {presupuesto.Id} no generado por un error: {result.Mensaje}");
                    response.Add(new PresupuestoResponse(result.Titulo, result.Mensaje));
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
