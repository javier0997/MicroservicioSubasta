using MediatR;

namespace ProductoService.Application.Commands;

public record DeleteProductoCommand(int Id) : IRequest; 