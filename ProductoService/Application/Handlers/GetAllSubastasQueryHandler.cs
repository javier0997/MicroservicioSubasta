using MediatR;
using ProductoService.Application.DTOs;
using ProductoService.Application.Queries;
using ProductoService.Application.Services;

namespace ProductoService.Application.Handlers;

public class GetAllSubastasQueryHandler : IRequestHandler<GetAllSubastasQuery, IEnumerable<SubastaDto>>
{
    private readonly ISubastaService _subastaService;

    public GetAllSubastasQueryHandler(ISubastaService subastaService)
    {
        _subastaService = subastaService;
    }

    public async Task<IEnumerable<SubastaDto>> Handle(GetAllSubastasQuery request, CancellationToken cancellationToken)
    {
        return await _subastaService.GetAllAsync();
    }
} 