using APISoftlandAnclaflex.Entities;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Repositories
{
    public class RepositoryBase
    {

        public ANCLAFContext Context { get; }
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        public RepositoryBase(ANCLAFContext context, IConfiguration configuration, Serilog.ILogger logger)
        {
            Context = context;
            Configuration = configuration;
            Logger = logger;
        }

    }

}
