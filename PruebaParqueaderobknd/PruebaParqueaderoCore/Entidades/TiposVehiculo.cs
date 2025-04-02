using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaParqueaderoCore.Entidades;

public partial class TiposVehiculo
{
    [Key]
    public int IdTipoVehiculo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreTipoVehiculo { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TarifaPorMinuto { get; set; }

    public bool? EstadoTipoVehiculo { get; set; }

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

    [InverseProperty("IdTipoVehiculoNavigation")]
    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
