using Microsoft.AspNetCore.Mvc;
using PruebaParqueaderoCore.Dtos;
using PruebaParqueaderoCore.Interfaces;

namespace PruebaParqueaderoPresentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupermercadosController : ControllerBase
    {
        private readonly ISupermercadoService _supermercadoService;

        public SupermercadosController(ISupermercadoService supermercadoService)
        {
            _supermercadoService = supermercadoService;
        }

        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarSupermercado([FromBody] SupermercadoDto supermercadoDto)
        {
            if (supermercadoDto == null)
                return BadRequest("Los datos son inválidos.");

            var resultado = await _supermercadoService.InsertarSupermercado(supermercadoDto);
            if (resultado > 0)
                return Ok(new { mensaje = "Supermercado insertado correctamente." });

            return BadRequest("No se pudo insertar el supermercado.");
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerSupermercados()
        {
            var supermercados = await _supermercadoService.ObtenerSupermercados();
            return Ok(supermercados);
        }
    }
}
