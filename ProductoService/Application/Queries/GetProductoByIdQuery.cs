using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Queries;

public record GetProductoByIdQuery(int Id) : IRequest<ProductoDto?>; 