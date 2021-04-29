﻿using APISoftlandAnclaflex.Entities;
using APISoftlandAnclaflex.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Repositories
{
    public class UsuariosRepository:RepositoryBase<Usuario>
    {
        public UsuariosRepository(ANCLAFContext context, IConfiguration configuration, Serilog.ILogger logger): 
            base(context, configuration, logger)
        {

        }
    }
}
