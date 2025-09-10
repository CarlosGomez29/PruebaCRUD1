using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaCRUD1.Models;

public partial class PruebaTecnicaCrudContext : DbContext
{
    public PruebaTecnicaCrudContext()
    {
    }

    public PruebaTecnicaCrudContext(DbContextOptions<PruebaTecnicaCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Historial> Historials { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Historial>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__Historia__9CC7DBB49EB736EF");

            entity.ToTable("Historial");

            entity.Property(e => e.Accion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Detalles)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.FechaAccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(30, 2)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Historials)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Historial__IdPro__4E88ABD4");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__098892106379F76D");

            entity.ToTable("Producto");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCrea)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaMod).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(30, 2)");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVentas).HasName("PK__Ventas__FF40C89FDE3D033D");

            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PrecioTotal)
                .HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", true)
                .HasColumnType("decimal(38, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(30, 2)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Ventas__IdProduc__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
