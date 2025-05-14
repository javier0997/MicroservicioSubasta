using ProductoService.Domain.Entities;

namespace ProductoService.Domain.Interfaces;

public interface IProductoRepository
{
    Task<Producto?> GetByIdAsync(int id);
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<IEnumerable<Producto>> GetByVendedorIdAsync(int vendedorId);
    Task<IEnumerable<Producto>> GetByCategoriaAsync(string categoria);
    Task<Producto> AddAsync(Producto producto);
    Task<Producto> UpdateAsync(Producto producto);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
} 