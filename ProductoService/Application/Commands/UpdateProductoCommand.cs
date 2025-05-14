using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Commands;

public record UpdateProductoCommand(int Id, UpdateProductoDto Producto) : IRequest<ProductoDto>; 