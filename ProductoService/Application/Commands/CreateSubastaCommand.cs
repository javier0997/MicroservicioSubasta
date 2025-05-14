using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Commands;

public record CreateSubastaCommand(CreateSubastaDto Subasta) : IRequest<SubastaDto>; 