using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaParqueaderoCore.Entidades;

public partial class RegistrosVehiculo
{
    [Key]
    public long IdRegistroVehiculo { get; set; }

    public int? IdSupermercado { get; set; }

    public int IdVehiculo { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? NumeroFactura { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaEntrada { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaSalida { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalPagado { get; set; }

    public bool? EstadoRegistroVehiculo { get; set; }

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

    [ForeignKey("IdSupermercado")]
    [InverseProperty("RegistrosVehiculos")]
    public virtual Supermercado? IdSupermercadoNavigation { get; set; }

    [ForeignKey("IdVehiculo")]
    [InverseProperty("RegistrosVehiculos")]
    public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
}
