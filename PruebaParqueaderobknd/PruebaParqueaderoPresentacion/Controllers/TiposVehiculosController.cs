using Microsoft.AspNetCore.Mvc;
using PruebaParqueaderoCore.Dtos;
using PruebaParqueaderoCore.Interfaces;
using PruebaParqueaderoCore.Servicios;

namespace PruebaParqueaderoPresentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposVehiculosController : ControllerBase
    {
        private readonly ITipoVehiculoService _tipoVehiculoService;

        public TiposVehiculosController(ITipoVehiculoService tipoVehiculoService)
        {
            _tipoVehiculoService = tipoVehiculoService;
        }

        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarTipoVehiculo([FromBody] TipoVehiculoDto tipoVehiculoDto)
        {
            if (tipoVehiculoDto == null)
                return BadRequest("Los datos son inválidos.");

            var resultado = await _tipoVehiculoService.InsertarTipoVehiculo(tipoVehiculoDto);
            if (resultado > 0)
                return Ok(new { mensaje = "Tipo de vehículo insertado correctamente." });

            return BadRequest("No se pudo insertar el tipo de vehículo.");
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTiposVehiculo()
        {
            var tipos = await _tipoVehiculoService.ObtenerTiposVehiculo();
            return Ok(tipos);
        }
    }
}
