using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Response;

namespace Repositorios.Mensaje
{
    public interface IMensajeRepositorio
    {
        Task<CrinnsoResponse<string>> GetCurrentDateTimeAsync();
    }
}
