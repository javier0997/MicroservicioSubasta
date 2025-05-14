using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Queries;

public record GetProductosByCategoriaQuery(string Categoria) : IRequest<IEnumerable<ProductoDto>>; 