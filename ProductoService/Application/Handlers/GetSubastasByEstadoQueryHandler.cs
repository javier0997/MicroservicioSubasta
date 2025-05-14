using MediatR;
using ProductoService.Application.DTOs;
using ProductoService.Application.Queries;
using ProductoService.Application.Services;

namespace ProductoService.Application.Handlers;

public class GetSubastasByEstadoQueryHandler : IRequestHandler<GetSubastasByEstadoQuery, IEnumerable<SubastaDto>>
{
    private readonly ISubastaService _subastaService;

    public GetSubastasByEstadoQueryHandler(ISubastaService subastaService)
    {
        _subastaService = subastaService;
    }

    public async Task<IEnumerable<SubastaDto>> Handle(GetSubastasByEstadoQuery request, CancellationToken cancellationToken)
    {
        return await _subastaService.GetByEstadoAsync(request.Estado);
    }
} 