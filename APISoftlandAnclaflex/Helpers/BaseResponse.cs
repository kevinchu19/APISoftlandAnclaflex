﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Helpers
{
    public abstract class BaseResponse<T>
    {
        public int Estado { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }

        protected BaseResponse(string titulo, int idOperacion)
        {
            Estado = 200;
            Mensaje = "Registro generado con éxito";
            Titulo = titulo;
        }

        protected BaseResponse(string titulo, int idOperacion, T resource)
        {
            Estado = 200;
            Mensaje = "Registro generado con éxito";
            Titulo = titulo;
        }

        protected BaseResponse(string titulo, int idOperacion, string message)
        {
            Estado = 400;
            Mensaje = message;
            Titulo = titulo;
        }
    }

}
