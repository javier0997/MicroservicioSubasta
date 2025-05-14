using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Queries;

public record GetProductosBySubastadorQuery(int SubastadorId) : IRequest<IEnumerable<ProductoDto>>; 