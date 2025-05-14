using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Commands;

public record CreateProductoCommand : IRequest<ProductoDto>
{
    public string Nombre { get; init; } = string.Empty;
    public string Descripcion { get; init; } = string.Empty;
    public decimal PrecioBase { get; init; }
    public string Categoria { get; init; } = string.Empty;
    public string? ImagenUrl { get; init; }
    public int SubastadorId { get; init; }
} 