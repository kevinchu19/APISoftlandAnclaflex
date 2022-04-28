using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using APISoftlandAnclaflex.Entities;
using APISoftlandAnclaflex.Helpers;
using APISoftlandAnclaflex.Models;
using APISoftlandAnclaflex.Repositories;
using APISoftlandAnclaflex.Services;

using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace APISoftlandAnclaflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaCorrienteController : ControllerBase
    {
        public PedidoRepository _repository { get; }
        public IMapper _mapper { get; }
        public IDataProtector _dataProtector { get; }
        public IConfiguration _configuration { get; }

        private readonly Serilog.ILogger _logger;

        public CuentaCorrienteController(Serilog.ILogger logger, IDataProtectionProvider dataprovider, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _dataProtector = dataprovider.CreateProtector("K:2879rojo");
            
        }

        [HttpGet("file/{imageUrl}")]
        public async Task<IActionResult> Get(string imageUrl)
        {
            var a = this._dataProtector.Protect("hola");
            var b = this._dataProtector.Unprotect(a);
            var imageUrlDecoded = this._dataProtector.Unprotect((string)imageUrl);
            var stream = new FileStream($"{_configuration["PdfCuentaCorrientePath"]}\\{imageUrlDecoded}", FileMode.Open);
            return File(stream, "application/pdf", stream.Name);
        }


    }
}
