using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Interfaces
{
    public interface IStoredProcedureRepository
    {
        Task<List<T>> ExecuteStoredProcedure<T>(string storedProcedure, params object[] parameters) where T : class;
        Task<int> ExecuteNonQueryStoredProcedure(string storedProcedure, params object[] parameters);

    }
}
