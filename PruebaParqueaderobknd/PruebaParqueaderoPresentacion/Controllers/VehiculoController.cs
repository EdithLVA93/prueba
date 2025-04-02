using Microsoft.AspNetCore.Mvc;
using PruebaParqueaderoCore.Dtos;
using PruebaParqueaderoCore.Interfaces;

namespace PruebaParqueaderoPresentacion.Controllers
{
    [ApiController]
    [Route("api/vehiculos")]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        /// <summary>
        /// Obtiene los vehículos estacionados en un rango de fechas
        /// </summary>
        [HttpGet("ListadoVehiculos")]
        public async Task<IActionResult> ObtenerListadoVehiculos([FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            var vehiculos = await _vehiculoService.ObtenerVehiculosEstacionados(fechaInicio, fechaFin);
            if (vehiculos == null || vehiculos.Count == 0)
                return NotFound(new { mensaje = "No se encontraron vehículos estacionados en ese rango de fechas." });

            return Ok(vehiculos);
        }

        /// <summary>
        /// Registra el ingreso de un vehículo al parqueadero
        /// </summary>
        [HttpPost("registrar-ingreso")]
        public async Task<IActionResult> RegistrarIngreso([FromBody] RegistrarIngresoRequest request)
        {
            int idRegistro = await _vehiculoService.RegistrarIngreso(
                request.IdTipoVehiculo, request?.Placa,  request?.UsuarioCreacion);

            if (idRegistro > 0)
                return Ok(new { mensaje = "Ingreso registrado con éxito.", idRegistro });
            else
                return BadRequest(new { mensaje = "Error al registrar el ingreso del vehículo." });
        }

        /// <summary>
        /// Liquida la salida de un vehículo
        /// </summary>
        [HttpPost("liquidar-salida")]
        public async Task<IActionResult> LiquidarSalidaVehiculo([FromBody] LiquidarSalidaRequest request)
        {
            bool resultado = await _vehiculoService.LiquidarSalidaVehiculo(
                request?.Placa, request?.NumeroFactura, request?.IdSupermercado, request?.UsuarioActualizacion);

            if (resultado)
                return Ok(new { mensaje = "Liquidación realizada con éxito." });
            else
                return BadRequest(new { mensaje = "Error al liquidar la salida del vehículo." });
        }
    }

}
