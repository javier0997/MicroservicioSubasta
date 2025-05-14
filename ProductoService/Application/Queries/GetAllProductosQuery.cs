using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Queries;

public record GetAllProductosQuery() : IRequest<IEnumerable<ProductoDto>>; 