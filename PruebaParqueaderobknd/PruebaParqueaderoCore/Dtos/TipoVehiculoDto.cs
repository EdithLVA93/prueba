using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Dtos
{
    public class TipoVehiculoDto
    {
        public int IdTipoVehiculo { get; set; }
        public string? NombreTipoVehiculo { get; set; }
        public decimal TarifaPorMinuto { get; set; }
        public bool EstadoTipoVehiculo { get; set; }
        public string? UsuarioCreacion { get; set; }
    }

}
