using Microsoft.EntityFrameworkCore;
using ProductoService.Domain.Entities;
using ProductoService.Domain.Interfaces;
using ProductoService.Infrastructure.Data;

namespace ProductoService.Infrastructure.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly ProductoDbContext _context;

    public ProductoRepository(ProductoDbContext context)
    {
        _context = context;
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _context.Productos.FindAsync(id);
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos.ToListAsync();
    }

    public async Task<IEnumerable<Producto>> GetByVendedorIdAsync(int propietarioId)
    {
        return await _context.Productos
            .Where(p => p.PropietarioId == propietarioId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Producto>> GetByCategoriaAsync(string categoria)
    {
        return await _context.Productos
            .Where(p => p.Categoria == categoria)
            .ToListAsync();
    }

    public async Task<Producto> AddAsync(Producto producto)
    {
        producto.FechaRegistro = DateTime.UtcNow;
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<Producto> UpdateAsync(Producto producto)
    {
        var existingProducto = await _context.Productos.FindAsync(producto.Id);
        if (existingProducto == null)
            throw new KeyNotFoundException($"Producto con ID {producto.Id} no encontrado");

        // Solo actualiza los campos permitidos
        existingProducto.Nombre = producto.Nombre;
        existingProducto.Descripcion = producto.Descripcion;
        existingProducto.Categoria = producto.Categoria;
        existingProducto.ImagenUrl = producto.ImagenUrl;
        // No se actualiza PropietarioId ni FechaRegistro

        await _context.SaveChangesAsync();
        return existingProducto;
    }

    public async Task DeleteAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto != null)
        {
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Productos.AnyAsync(p => p.Id == id);
    }
} 