using PruebaParqueaderoCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Interfaces
{
    public interface IVehiculoService
    {
        Task<List<VehiculoDto>> ObtenerVehiculosEstacionados(string fechaInicio, string fechaFin);
        Task<int> RegistrarIngreso(int tipoVehiculo, string? placa, string? usuario);
        Task<bool> LiquidarSalidaVehiculo(string? placa, string? numeroFactura, int? idSupermercado, string? usuarioActualizacion);

    }
}
