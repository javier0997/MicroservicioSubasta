using AutoMapper;
using ProductoService.Application.DTOs;
using ProductoService.Domain.Entities;
using ProductoService.Domain.Interfaces;

namespace ProductoService.Application.Services;

public interface IProductoService
{
    Task<ProductoDto?> GetByIdAsync(int id);
    Task<IEnumerable<ProductoDto>> GetAllAsync();
    Task<IEnumerable<ProductoDto>> GetByVendedorIdAsync(int vendedorId);
    Task<IEnumerable<ProductoDto>> GetByCategoriaAsync(string categoria);
    Task<ProductoDto> CreateAsync(CreateProductoDto productoDto);
    Task<ProductoDto> UpdateAsync(int id, UpdateProductoDto productoDto);
    Task DeleteAsync(int id);
}

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repository;
    private readonly IMapper _mapper;

    public ProductoService(IProductoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductoDto?> GetByIdAsync(int id)
    {
        var producto = await _repository.GetByIdAsync(id);
        return producto != null ? _mapper.Map<ProductoDto>(producto) : null;
    }

    public async Task<IEnumerable<ProductoDto>> GetAllAsync()
    {
        var productos = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductoDto>>(productos);
    }

    public async Task<IEnumerable<ProductoDto>> GetByVendedorIdAsync(int vendedorId)
    {
        var productos = await _repository.GetByVendedorIdAsync(vendedorId);
        return _mapper.Map<IEnumerable<ProductoDto>>(productos);
    }

    public async Task<IEnumerable<ProductoDto>> GetByCategoriaAsync(string categoria)
    {
        var productos = await _repository.GetByCategoriaAsync(categoria);
        return _mapper.Map<IEnumerable<ProductoDto>>(productos);
    }

    public async Task<ProductoDto> CreateAsync(CreateProductoDto productoDto)
    {
        var producto = _mapper.Map<Producto>(productoDto);
        var createdProducto = await _repository.AddAsync(producto);
        return _mapper.Map<ProductoDto>(createdProducto);
    }

    public async Task<ProductoDto> UpdateAsync(int id, UpdateProductoDto productoDto)
    {
        var existingProducto = await _repository.GetByIdAsync(id);
        if (existingProducto == null)
            throw new KeyNotFoundException($"Producto con ID {id} no encontrado");

        var producto = _mapper.Map<Producto>(productoDto);
        producto.Id = id;
        
        var updatedProducto = await _repository.UpdateAsync(producto);
        return _mapper.Map<ProductoDto>(updatedProducto);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
} 