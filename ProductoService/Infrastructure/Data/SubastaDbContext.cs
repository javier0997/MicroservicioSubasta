using Microsoft.EntityFrameworkCore;
using ProductoService.Domain.Entities;

namespace ProductoService.Infrastructure.Data;

public class SubastaDbContext : DbContext
{
    public SubastaDbContext(DbContextOptions<SubastaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Subasta> Subastas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subasta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PrecioBase).HasColumnType("decimal(18,2)");
            entity.Property(e => e.IncrementoMinimo).HasColumnType("decimal(18,2)");
            entity.Property(e => e.PrecioReserva).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Tipo).IsRequired().HasMaxLength(50);
            entity.Property(e => e.FechaInicio).IsRequired();
            entity.Property(e => e.FechaFin).IsRequired();
            entity.Property(e => e.Estado).IsRequired().HasMaxLength(50);
            entity.Property(e => e.SubastadorId).IsRequired();
            entity.Property(e => e.FechaCreacion).IsRequired();
            entity.Property(e => e.FechaActualizacion).IsRequired();
            entity.HasOne(e => e.Producto)
                  .WithMany()
                  .HasForeignKey(e => e.ProductoId);
        });
    }
} 