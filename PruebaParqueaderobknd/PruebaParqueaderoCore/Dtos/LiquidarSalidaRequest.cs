using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Dtos
{
    public class LiquidarSalidaRequest
    {
        public string? Placa { get; set; }
        public string? NumeroFactura { get; set; }
        public int IdSupermercado { get; set; }
        public string? UsuarioActualizacion { get; set; }
    }

}
