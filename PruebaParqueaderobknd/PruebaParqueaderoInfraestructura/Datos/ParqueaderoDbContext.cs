using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PruebaParqueaderoCore.Dtos;
using PruebaParqueaderoCore.Entidades;

namespace PruebaParqueaderoInfraestructura.Datos;

public partial class ParqueaderoDbContext : DbContext
{
    public ParqueaderoDbContext()
    {
    }

    public ParqueaderoDbContext(DbContextOptions<ParqueaderoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RegistrosVehiculo> RegistrosVehiculos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supermercado> Supermercados { get; set; }

    public virtual DbSet<TiposVehiculo> TiposVehiculos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehiculoDto>().HasNoKey();

        modelBuilder.Entity<RegistrosVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdRegistroVehiculo).HasName("PK__Registro__8A97106731BFAD70");

            entity.HasOne(d => d.IdSupermercadoNavigation).WithMany(p => p.RegistrosVehiculos).HasConstraintName("FK_RegistrosVehiculos_Supermercados");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.RegistrosVehiculos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrosVehiculos_Vehiculos");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C45D836C1");
        });

        modelBuilder.Entity<Supermercado>(entity =>
        {
            entity.HasKey(e => e.IdSupermercado).HasName("PK__Supermer__DAA860C5687D3168");
        });

        modelBuilder.Entity<TiposVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdTipoVehiculo).HasName("PK__TiposVeh__DC20741E46022070");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF974F736FA8");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios).HasConstraintName("FK_Usuarios_Roles");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("PK__Vehiculo__708612150D9F718C");

            entity.HasOne(d => d.IdTipoVehiculoNavigation).WithMany(p => p.Vehiculos).HasConstraintName("FK_Vehiculos_TiposVehiculos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
