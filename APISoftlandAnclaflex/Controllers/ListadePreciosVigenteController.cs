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
    public class ListadePreciosVigenteController : ControllerBase
    {
        public IConfiguration _configuration { get; }

        private readonly Serilog.ILogger _logger;

        public ListadePreciosVigenteController(Serilog.ILogger logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
          
        }

        [HttpGet("file")]
        public async Task<IActionResult> Get()
        {
            var directory = new DirectoryInfo($"{_configuration["PdfListadePreciosPath"]}");
            var myFile = directory.GetFiles()
             .OrderByDescending(f => f.LastWriteTime)
             .First();
            var stream = new FileStream(myFile.FullName, FileMode.Open);
            return File(stream, "application/pdf", myFile.Name);
        }


    }
}
