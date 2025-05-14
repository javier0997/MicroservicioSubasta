using MediatR;
using ProductoService.Application.DTOs;

namespace ProductoService.Application.Queries;

public record GetSubastasByEstadoQuery(string Estado) : IRequest<IEnumerable<SubastaDto>>; 