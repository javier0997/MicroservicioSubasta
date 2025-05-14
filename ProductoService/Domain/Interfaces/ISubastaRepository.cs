using ProductoService.Domain.Entities;

namespace ProductoService.Domain.Interfaces;

public interface ISubastaRepository
{
    Task<Subasta?> GetByIdAsync(int id);
    Task<IEnumerable<Subasta>> GetAllAsync();
    Task<IEnumerable<Subasta>> GetBySubastadorIdAsync(int subastadorId);
    Task<IEnumerable<Subasta>> GetByEstadoAsync(string estado);
    Task<Subasta> AddAsync(Subasta subasta);
    Task<Subasta> UpdateAsync(Subasta subasta);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
} 