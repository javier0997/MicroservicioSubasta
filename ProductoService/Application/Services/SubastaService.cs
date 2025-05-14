using AutoMapper;
using ProductoService.Application.DTOs;
using ProductoService.Domain.Entities;
using ProductoService.Domain.Interfaces;

namespace ProductoService.Application.Services;

public interface ISubastaService
{
    Task<SubastaDto?> GetByIdAsync(int id);
    Task<IEnumerable<SubastaDto>> GetAllAsync();
    Task<IEnumerable<SubastaDto>> GetBySubastadorIdAsync(int subastadorId);
    Task<IEnumerable<SubastaDto>> GetByEstadoAsync(string estado);
    Task<SubastaDto> CreateAsync(CreateSubastaDto subastaDto);
    Task<SubastaDto> UpdateAsync(int id, UpdateSubastaDto subastaDto);
    Task DeleteAsync(int id);
}

public class SubastaService : ISubastaService
{
    private readonly ISubastaRepository _repository;
    private readonly IMapper _mapper;

    public SubastaService(ISubastaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SubastaDto?> GetByIdAsync(int id)
    {
        var subasta = await _repository.GetByIdAsync(id);
        return subasta != null ? _mapper.Map<SubastaDto>(subasta) : null;
    }

    public async Task<IEnumerable<SubastaDto>> GetAllAsync()
    {
        var subastas = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<SubastaDto>>(subastas);
    }

    public async Task<IEnumerable<SubastaDto>> GetBySubastadorIdAsync(int subastadorId)
    {
        var subastas = await _repository.GetBySubastadorIdAsync(subastadorId);
        return _mapper.Map<IEnumerable<SubastaDto>>(subastas);
    }

    public async Task<IEnumerable<SubastaDto>> GetByEstadoAsync(string estado)
    {
        var subastas = await _repository.GetByEstadoAsync(estado);
        return _mapper.Map<IEnumerable<SubastaDto>>(subastas);
    }

    public async Task<SubastaDto> CreateAsync(CreateSubastaDto subastaDto)
    {
        var subasta = _mapper.Map<Subasta>(subastaDto);
        var createdSubasta = await _repository.AddAsync(subasta);
        return _mapper.Map<SubastaDto>(createdSubasta);
    }

    public async Task<SubastaDto> UpdateAsync(int id, UpdateSubastaDto subastaDto)
    {
        var existingSubasta = await _repository.GetByIdAsync(id);
        if (existingSubasta == null)
            throw new KeyNotFoundException($"Subasta con ID {id} no encontrada");

        // Mapear solo los campos actualizables
        if (subastaDto.PrecioBase.HasValue) existingSubasta.PrecioBase = subastaDto.PrecioBase.Value;
        if (subastaDto.IncrementoMinimo.HasValue) existingSubasta.IncrementoMinimo = subastaDto.IncrementoMinimo.Value;
        if (subastaDto.PrecioReserva.HasValue) existingSubasta.PrecioReserva = subastaDto.PrecioReserva.Value;
        if (!string.IsNullOrEmpty(subastaDto.Tipo)) existingSubasta.Tipo = subastaDto.Tipo!;
        if (subastaDto.FechaInicio.HasValue) existingSubasta.FechaInicio = subastaDto.FechaInicio.Value;
        if (subastaDto.FechaFin.HasValue) existingSubasta.FechaFin = subastaDto.FechaFin.Value;
        if (!string.IsNullOrEmpty(subastaDto.Estado)) existingSubasta.Estado = subastaDto.Estado!;

        var updatedSubasta = await _repository.UpdateAsync(existingSubasta);
        return _mapper.Map<SubastaDto>(updatedSubasta);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
} 