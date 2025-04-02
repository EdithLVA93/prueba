using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore.Dtos
{
    public class VehiculoDto
    {

        public string? Placa { get; set; }
        public string? NombreTipoVehiculo { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int TiempoParqueo { get; set; }
        public decimal TotalPagado { get; set; }
    }
}
