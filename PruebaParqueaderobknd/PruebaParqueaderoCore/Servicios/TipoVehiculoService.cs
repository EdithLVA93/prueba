using PruebaParqueaderoCore.Dtos;
using PruebaParqueaderoCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Servicios
{
    public class TipoVehiculoService : ITipoVehiculoService
    {
        private readonly ITipoVehiculoRepositorio _tipoVehiculoRepositorio;

        public TipoVehiculoService(ITipoVehiculoRepositorio tipoVehiculoRepositorio)
        {
            _tipoVehiculoRepositorio = tipoVehiculoRepositorio;
        }

        public async Task<int> InsertarTipoVehiculo(TipoVehiculoDto tipoVehiculoDto)
        {
            return await _tipoVehiculoRepositorio.InsertarTipoVehiculo(tipoVehiculoDto);
        }

        public async Task<List<TipoVehiculoDto>> ObtenerTiposVehiculo()
        {
            var tipos = await _tipoVehiculoRepositorio.ObtenerTiposVehiculo();
            return tipos.Select(t => new TipoVehiculoDto { IdTipoVehiculo = t.IdTipoVehiculo, NombreTipoVehiculo = t.NombreTipoVehiculo }).ToList();
        }
    }
}
