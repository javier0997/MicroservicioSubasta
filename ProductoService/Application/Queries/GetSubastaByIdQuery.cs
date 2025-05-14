using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Queries;

public record GetSubastaByIdQuery(int Id) : IRequest<SubastaDto?>; 