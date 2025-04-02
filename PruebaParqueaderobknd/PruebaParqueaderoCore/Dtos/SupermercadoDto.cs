using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Dtos
{
    public class SupermercadoDto
    {
        public int IdSupermercado { get; set; }
        public string? NombreSupermercado { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public bool EstadoSupermercado { get; set; }
        public string? UsuarioCreacion { get; set; }
    }

}
