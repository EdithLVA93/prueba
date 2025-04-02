using Microsoft.EntityFrameworkCore;
using PruebaParqueaderoCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoInfraestructura.Datos
{
    public class StoredProcedureRepository: IStoredProcedureRepository
    {
        private readonly ParqueaderoDbContext _context;

        public StoredProcedureRepository(ParqueaderoDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> ExecuteStoredProcedure<T>(string storedProcedure, params object[] parameters) where T : class
        {
            try
            {

                return await _context.Set<T>().FromSqlRaw(storedProcedure, parameters).ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ExecuteNonQueryStoredProcedure(string storedProcedure, params object[] parameters)
        {
            try
            {
                var result = await _context.RegistrosVehiculos
              .FromSqlRaw(storedProcedure, parameters).ToListAsync();
                return (int)result.LastOrDefault().IdRegistroVehiculo;
            }catch(Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
