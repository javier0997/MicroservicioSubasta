using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Queries;

public record GetSubastasBySubastadorQuery(int SubastadorId) : IRequest<IEnumerable<SubastaDto>>; 