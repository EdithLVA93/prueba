using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Dtos
{
    public class RegistrarIngresoRequest
    {
        public int IdTipoVehiculo { get; set; }
        public string? Placa { get; set; }
        public string? UsuarioCreacion { get; set; }
    }

}
