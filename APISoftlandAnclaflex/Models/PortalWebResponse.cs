using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Models
{
    public class PortalWebResponse
    {
        public int estado { get; set; }
        public string titulo { get; set; }
        public string mensaje { get; set; }
        public object? resource { get; set; }

    }
}
