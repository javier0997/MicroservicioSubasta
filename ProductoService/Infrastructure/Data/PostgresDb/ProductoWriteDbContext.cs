using Microsoft.EntityFrameworkCore;
using ProductoService.Domain.Entities;

namespace ProductoService.Infrastructure.Data.PostgresDb;

public class ProductoWriteDbContext : DbContext
{
    public ProductoWriteDbContext(DbContextOptions<ProductoWriteDbContext> options)
        : base(options)
    {
    }

    public DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Categoria).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ImagenUrl).HasMaxLength(500);
            entity.Property(e => e.FechaRegistro).IsRequired();
            entity.Property(e => e.PropietarioId).IsRequired();
        });
    }
} 