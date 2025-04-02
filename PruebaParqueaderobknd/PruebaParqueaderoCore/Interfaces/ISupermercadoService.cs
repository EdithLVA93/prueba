using PruebaParqueaderoCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Interfaces
{
    public interface ISupermercadoService
    {
        Task<int> InsertarSupermercado(SupermercadoDto supermercadoDto);
        Task<List<SupermercadoDto>> ObtenerSupermercados();
    }
}
