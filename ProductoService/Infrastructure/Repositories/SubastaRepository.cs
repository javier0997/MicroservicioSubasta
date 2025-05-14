using Microsoft.EntityFrameworkCore;
using ProductoService.Domain.Entities;
using ProductoService.Domain.Interfaces;
using ProductoService.Infrastructure.Data;

namespace ProductoService.Infrastructure.Repositories;

public class SubastaRepository : ISubastaRepository
{
    private readonly SubastaDbContext _context;

    public SubastaRepository(SubastaDbContext context)
    {
        _context = context;
    }

    public async Task<Subasta?> GetByIdAsync(int id)
    {
        return await _context.Subastas.Include(s => s.Producto).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Subasta>> GetAllAsync()
    {
        return await _context.Subastas.Include(s => s.Producto).ToListAsync();
    }

    public async Task<IEnumerable<Subasta>> GetBySubastadorIdAsync(int subastadorId)
    {
        return await _context.Subastas.Include(s => s.Producto)
            .Where(s => s.SubastadorId == subastadorId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Subasta>> GetByEstadoAsync(string estado)
    {
        return await _context.Subastas.Include(s => s.Producto)
            .Where(s => s.Estado == estado)
            .ToListAsync();
    }

    public async Task<Subasta> AddAsync(Subasta subasta)
    {
        subasta.FechaCreacion = DateTime.UtcNow;
        subasta.FechaActualizacion = DateTime.UtcNow;
        _context.Subastas.Add(subasta);
        await _context.SaveChangesAsync();
        return subasta;
    }

    public async Task<Subasta> UpdateAsync(Subasta subasta)
    {
        var existingSubasta = await _context.Subastas.FindAsync(subasta.Id);
        if (existingSubasta == null)
            throw new KeyNotFoundException($"Subasta con ID {subasta.Id} no encontrada");

        existingSubasta.PrecioBase = subasta.PrecioBase;
        existingSubasta.IncrementoMinimo = subasta.IncrementoMinimo;
        existingSubasta.PrecioReserva = subasta.PrecioReserva;
        existingSubasta.Tipo = subasta.Tipo;
        existingSubasta.FechaInicio = subasta.FechaInicio;
        existingSubasta.FechaFin = subasta.FechaFin;
        existingSubasta.Estado = subasta.Estado;
        existingSubasta.FechaActualizacion = DateTime.UtcNow;
        // No se actualiza ProductoId ni SubastadorId ni FechaCreacion

        await _context.SaveChangesAsync();
        return existingSubasta;
    }

    public async Task DeleteAsync(int id)
    {
        var subasta = await _context.Subastas.FindAsync(id);
        if (subasta != null)
        {
            _context.Subastas.Remove(subasta);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Subastas.AnyAsync(s => s.Id == id);
    }
} 