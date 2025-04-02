using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaParqueaderoCore.Entidades;

public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NombreUsuario { get; set; } = null!;

    public int? IdRol { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Contrasena { get; set; } = null!;

    public bool EstadoUsuario { get; set; }

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

    [ForeignKey("IdRol")]
    [InverseProperty("Usuarios")]
    public virtual Role? IdRolNavigation { get; set; }
}
