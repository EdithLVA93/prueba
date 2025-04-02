using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaParqueaderoCore.Entidades;

public partial class Supermercado
{
    [Key]
    public int IdSupermercado { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NombreSupermercado { get; set; }

    public bool? EstadoSupermercado { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? PorcentajeDescuento { get; set; }

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

    [InverseProperty("IdSupermercadoNavigation")]
    public virtual ICollection<RegistrosVehiculo> RegistrosVehiculos { get; set; } = new List<RegistrosVehiculo>();
}
