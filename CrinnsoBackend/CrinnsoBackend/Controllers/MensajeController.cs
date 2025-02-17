using Azure;
using CasosUso.Mensaje;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utils.Response;

namespace CrinnsoBackend.Controllers
{
    [Route("api/mensaje")]
    [ApiController]
    public class MensajeController : ControllerBase
    {
        private readonly IMensajeCasoUso mensajeCasoUso;
        private readonly ILogger<IMensajeCasoUso> _logger;

        public MensajeController(IMensajeCasoUso mensajeCasoUso, ILogger<IMensajeCasoUso> logger)
        {
            this.mensajeCasoUso = mensajeCasoUso;
            _logger = logger;
        }

        [HttpGet]
        public async Task<CrinnsoResponse<string>> GetCurrentDateTime()
        {
            var response = await mensajeCasoUso.GetCurrentDateTime();
            return response;
        }
    }
}
