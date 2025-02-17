using Azure;
using Microsoft.Extensions.Logging;
using Repositorios.Mensaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Response;

namespace CasosUso.Mensaje
{
    public class MensajeCasoUso:IMensajeCasoUso
    {

        private readonly IMensajeRepositorio mensajeRepositorio;
        private readonly ILogger<MensajeCasoUso> _logger;
        public MensajeCasoUso(IMensajeRepositorio mensajeRepositorio, ILogger<MensajeCasoUso> logger)
        {
            this.mensajeRepositorio = mensajeRepositorio;
            _logger = logger;
        }

        public async Task<CrinnsoResponse<string>> GetCurrentDateTime()
        {
            var response = new CrinnsoResponse<string>();

            try
            {
                var currentDateTime = await mensajeRepositorio.GetCurrentDateTimeAsync();

                if (currentDateTime.HasError)
                {
                    response.SetError(currentDateTime.Message);
                    response.HttpCode = currentDateTime.HttpCode;
                }
                else
                {
                    var message = $"Hola Mundo - {currentDateTime.Result}";
                    response.SetSuccess(message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la fecha");
                response.SetError("Hubo un error al procesar la solicitud.");
                response.HttpCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }

    }
}
