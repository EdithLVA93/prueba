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
    public class SupermercadoRepositorio : ISupermercadoRepositorio
    {
        private readonly ParqueaderoDbContext _context;

        public SupermercadoRepositorio(ParqueaderoDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertarSupermercado(SupermercadoDto supermercadoDto)
        {
            var nuevoSupermercado = new Supermercado
            {
                NombreSupermercado = supermercadoDto.NombreSupermercado,
                PorcentajeDescuento = supermercadoDto.PorcentajeDescuento,
                EstadoSupermercado = supermercadoDto.EstadoSupermercado,
                UsuarioCreacion = supermercadoDto.UsuarioCreacion,
                FechaCreacion = DateTime.UtcNow
            };

            await _context.Supermercados.AddAsync(nuevoSupermercado);
            await _context.SaveChangesAsync();

            return nuevoSupermercado.IdSupermercado; // Devuelve el ID del registro insertado
        }

        public async Task<List<Supermercado>> ObtenerSupermercados()
        {
            return await _context.Supermercados.ToListAsync();
        }
    }
}
