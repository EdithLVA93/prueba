using PruebaParqueaderoCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Interfaces
{
    public interface ITipoVehiculoService
    {
        Task<int> InsertarTipoVehiculo(TipoVehiculoDto tipoVehiculoDto);
        Task<List<TipoVehiculoDto>> ObtenerTiposVehiculo();
    }
}
