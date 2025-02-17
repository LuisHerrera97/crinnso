using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositorios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Response;

namespace Repositorios.Mensaje
{
    public class MensajeRepositorio:IMensajeRepositorio
    {
        private readonly ApplicationDbContext dbContext; 
        private readonly ILogger<MensajeRepositorio> _logger;

        public MensajeRepositorio(ApplicationDbContext dbContext, ILogger<MensajeRepositorio> logger)
        {
            this.dbContext = dbContext;
            this._logger = logger;
        }

        public async Task<CrinnsoResponse<string>> GetCurrentDateTimeAsync()
        {
            CrinnsoResponse<string> response = new CrinnsoResponse<string>();

            try
            {

                var result = await dbContext.Database.SqlQueryRaw<FechaDto>("SELECT GETDATE() AS Fecha").FirstOrDefaultAsync();
                response.SetSuccess(result?.Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al ejecutar el método {MethodName}", nameof(GetCurrentDateTimeAsync));
                response.SetError(ex);
            }
            return response;
        }
    }
}
