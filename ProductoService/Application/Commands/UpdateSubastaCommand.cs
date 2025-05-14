using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Commands;

public record UpdateSubastaCommand(int Id, UpdateSubastaDto Subasta) : IRequest<SubastaDto>; 