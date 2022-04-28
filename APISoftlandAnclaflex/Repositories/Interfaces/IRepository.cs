using APISoftlandAnclaflex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Repositories.Interfaces
{
    public interface IRepository<TResponse>
    {
        Task<ICollection<TResponse>> GetForPortalWeb(string objeto);
        Task ActualizaRecursoTransferido(int id, string transferido, string objeto);
        Task ActualizaComprobanteTransferido(TResponse comprobante, string transferido, string objeto);
    }
}
