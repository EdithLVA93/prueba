using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaParqueaderoCore.Entidades;

public partial class Vehiculo
{
    [Key]
    public int IdVehiculo { get; set; }

    public int? IdTipoVehiculo { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Placa { get; set; }

    public bool? EstadoVehiculo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioCreacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioActualizacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaActualizacion { get; set; }

    [ForeignKey("IdTipoVehiculo")]
    [InverseProperty("Vehiculos")]
    public virtual TiposVehiculo? IdTipoVehiculoNavigation { get; set; }

    [InverseProperty("IdVehiculoNavigation")]
    public virtual ICollection<RegistrosVehiculo> RegistrosVehiculos { get; set; } = new List<RegistrosVehiculo>();
}
