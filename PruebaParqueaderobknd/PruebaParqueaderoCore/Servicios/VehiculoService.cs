using Microsoft.Data.SqlClient;
using PruebaParqueaderoCore.Dtos;
using PruebaParqueaderoCore.Entidades;
using PruebaParqueaderoCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Servicios
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IStoredProcedureRepository _spRepository;

        public VehiculoService(IStoredProcedureRepository spRepository)
        {
            _spRepository = spRepository;
        }

        public async Task<List<VehiculoDto>> ObtenerVehiculosEstacionados(string fechaInicio, string fechaFin)
        {
            string storedProcedure = "EXEC sp_ListarVehiculosEstacionados @FechaInicio, @FechaFin";
            var parameters = new[]
{
    new SqlParameter("@FechaInicio", SqlDbType.DateTime) { Value = fechaInicio },
    new SqlParameter("@FechaFin", SqlDbType.DateTime) { Value = fechaFin }
};
            var result =  await _spRepository.ExecuteStoredProcedure<VehiculoDto>(storedProcedure, parameters);

            return result;
        }

        public async Task<int> RegistrarIngreso(int tipoVehiculo, string? placa,  string? usuario)
        {
            string storedProcedure = "EXEC sp_RegistrarIngresoVehiculo @IdTipoVehiculo, @Placa,  @UsuarioCreacion";

            var parameters = new[]
            {
        new SqlParameter("@IdTipoVehiculo", SqlDbType.Int) { Value = tipoVehiculo },
        new SqlParameter("@Placa", SqlDbType.VarChar, 10) { Value = placa ?? string.Empty },
        new SqlParameter("@UsuarioCreacion", SqlDbType.VarChar, 50) { Value = usuario ?? string.Empty }
    };

            return await _spRepository.ExecuteNonQueryStoredProcedure(storedProcedure, parameters);
        }

        public async Task<bool> LiquidarSalidaVehiculo(string? placa, string? numeroFactura, int? idSupermercado, string? usuarioActualizacion)
        {
            string storedProcedure = "EXEC sp_LiquidarSalidaVehiculo @Placa, @NumeroFactura, @IdSupermercado, @UsuarioActualizacion";

            var parameters = new[]
{
    new SqlParameter("@Placa", SqlDbType.VarChar, 10) { Value = placa ?? string.Empty },
    new SqlParameter("@IdSupermercado", SqlDbType.Int)
    {
        Value = (object?)idSupermercado ?? DBNull.Value
    },
    new SqlParameter("@NumeroFactura", SqlDbType.VarChar, 255)
    {
        Value = string.IsNullOrEmpty(numeroFactura) ? DBNull.Value : numeroFactura
    },
    new SqlParameter("@UsuarioActualizacion", SqlDbType.VarChar, 50)
    {
        Value = usuarioActualizacion ?? string.Empty
    }
};
            int result = await _spRepository.ExecuteNonQueryStoredProcedure(storedProcedure,
                parameters);

            return result > 0;
        }
    }
}
