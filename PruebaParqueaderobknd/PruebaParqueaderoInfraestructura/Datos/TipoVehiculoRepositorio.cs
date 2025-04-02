using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaParqueaderoCore.Dtos;
using PruebaParqueaderoCore.Entidades;
using PruebaParqueaderoCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoInfraestructura.Datos
{
    public class TipoVehiculoRepositorio : ITipoVehiculoRepositorio
    {
        private readonly ParqueaderoDbContext _context;

        public TipoVehiculoRepositorio(ParqueaderoDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertarTipoVehiculo(TipoVehiculoDto tipoVehiculoDto)
        {
            var nuevoTipoVehiculo = new TiposVehiculo
            {
                NombreTipoVehiculo = tipoVehiculoDto.NombreTipoVehiculo,
                TarifaPorMinuto = tipoVehiculoDto.TarifaPorMinuto,
                EstadoTipoVehiculo = tipoVehiculoDto.EstadoTipoVehiculo,
                UsuarioCreacion = tipoVehiculoDto.UsuarioCreacion,
                FechaCreacion = DateTime.UtcNow
            };

            await _context.TiposVehiculos.AddAsync(nuevoTipoVehiculo);
            await _context.SaveChangesAsync();

            return nuevoTipoVehiculo.IdTipoVehiculo; // Devuelve el ID del registro insertado
        }

        public async Task<List<TiposVehiculo>> ObtenerTiposVehiculo()
        {
            return await _context.TiposVehiculos.ToListAsync();
        }
    }
}
