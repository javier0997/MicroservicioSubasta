using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Queries;

public record GetAllSubastasQuery() : IRequest<IEnumerable<SubastaDto>>; 