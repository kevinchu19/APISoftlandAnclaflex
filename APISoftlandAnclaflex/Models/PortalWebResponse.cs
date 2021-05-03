using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Models
{
    public class PortalWebResponse
    {
        public int Estado { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string? Resource { get; set; }

    }
}
