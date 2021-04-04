using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Helpers
{
    public class FiltroDeExcepcion : ExceptionFilterAttribute, IExceptionFilter
    {
        public Serilog.ILogger logger { get; }

        public FiltroDeExcepcion(Serilog.ILogger logger)
        {
            this.logger = logger;
        }

        public async override void OnException(ExceptionContext context)
        {

            logger.Fatal(context.Exception.Message);

            var exception = context.Exception;

            PedidoResponse response = new PedidoResponse("", "") { };


            switch (context.Exception.GetType().ToString())
            {
                case "APINosis.Helpers.NotFoundException":
                    response.Estado = 404;
                    response.Titulo = "Not Found";
                    response.Mensaje = "El recurso solicitado no fue encontrado";
                    context.Result = new NotFoundObjectResult(response);
                    context.HttpContext.Response.StatusCode =
                        (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.Estado = 500;
                    response.Titulo = "Error interno de la aplicación";
                    response.Mensaje = exception.Message;
                    context.Result = new ObjectResult(response);
                    context.HttpContext.Response.StatusCode =
                              (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.ExceptionHandled = true;

        }
    }
}
