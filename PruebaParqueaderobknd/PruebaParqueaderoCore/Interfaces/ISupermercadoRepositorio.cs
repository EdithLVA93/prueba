using PruebaParqueaderoCore.Dtos;
using PruebaParqueaderoCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Interfaces
{
    public interface ISupermercadoRepositorio
    {
        Task<int> InsertarSupermercado(SupermercadoDto supermercadoDto);

        Task<List<Supermercado>> ObtenerSupermercados();
    }
}
