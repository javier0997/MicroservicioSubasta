using MediatR;

namespace ProductoService.Application.Commands;

public record DeleteSubastaCommand(int Id) : IRequest; 