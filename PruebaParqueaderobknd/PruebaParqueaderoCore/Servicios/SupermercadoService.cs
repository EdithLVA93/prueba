using PruebaParqueaderoCore.Dtos;
using PruebaParqueaderoCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Servicios
{
    public class SupermercadoService : ISupermercadoService
    {
        private readonly ISupermercadoRepositorio _supermercadoRepositorio;

        public SupermercadoService(ISupermercadoRepositorio supermercadoRepositorio)
        {
            _supermercadoRepositorio = supermercadoRepositorio;
        }

        public async Task<int> InsertarSupermercado(SupermercadoDto supermercadoDto)
        {
            return await _supermercadoRepositorio.InsertarSupermercado(supermercadoDto);
        }

        public async Task<List<SupermercadoDto>> ObtenerSupermercados()
        {
            var supermercados = await _supermercadoRepositorio.ObtenerSupermercados();
            return supermercados.Select(s => new SupermercadoDto { IdSupermercado = s.IdSupermercado, NombreSupermercado = s.NombreSupermercado, PorcentajeDescuento = s.PorcentajeDescuento }).ToList();
        }
    }
}
