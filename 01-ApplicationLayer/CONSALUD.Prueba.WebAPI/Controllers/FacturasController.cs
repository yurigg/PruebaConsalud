using CONSALUD.Prueba.WebAPI.AccessAuthorization;
using CONSALUD.Prueba.WebAPI.Domain;
using CONSALUD.Prueba.WebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CONSALUD.Prueba.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class FacturasController : ControllerBase
    {
        private readonly ILogger<FacturasController> _logger;
        private readonly FacturasService _FacturasService;

        public FacturasController(ILogger<FacturasController> logger, FacturasService facturasService)
        {
            _logger = logger;
            _FacturasService = facturasService;
        }

        
        [HttpGet("GetFactorurasYCalculaTotal")]
        [ProducesResponseType(typeof(List<FacturaCabeceraDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFactorurasYCalculaTotal()
        {

            List<FacturaCabeceraDto> Datos = _FacturasService.LeerFactorurasYCalculaTotal();

            return Datos == null ? NotFound() : Ok(Datos);
        }


 
        [HttpPost("GetFacturasPorRut")]
        [ProducesResponseType(typeof(FacturaCabeceraDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFacturasPorRut(double Rut)
        {

            List<FacturaCabeceraDto> Datos = _FacturasService.LeerFacturasPorRut(Rut);

            return (Datos == null || Datos.Count == 0) ? NotFound() : Ok(Datos);
        }


        [HttpGet("GetCompradorConMasCompras")]
        [ProducesResponseType(typeof(CompradorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCompradorConMasCompras()
        {

            CompradorDto Datos = _FacturasService.LeerCompradorConMasCompras();

            return Datos == null ? NotFound() : Ok(Datos);
        }



        [HttpGet("GetCompradoresConTotalCompras")]
        [ProducesResponseType(typeof(List<CompradorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCompradoresConTotalCompras()
        {

            List<CompradorDto> Datos = _FacturasService.LeerCompradoresConTotalCompras();

            return Datos == null ? NotFound() : Ok(Datos);
        }



        [HttpPost("GetAgrupadoPorComunas")]
        [ProducesResponseType(typeof(List<CompradorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAgrupadoPorComunas(double Comuna)
        {

            object[] Datos = _FacturasService.LeerAgrupadoPorComunas(Comuna);

            return (Datos == null || Datos.Length == 0) ? NotFound() : Ok(Datos);
        }

    }
}
