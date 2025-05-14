using MediatR;
using ProductoService.Application.DTOs;
using ProductoService.Application.Queries;
using ProductoService.Application.Services;

namespace ProductoService.Application.Handlers;

public class GetSubastasBySubastadorQueryHandler : IRequestHandler<GetSubastasBySubastadorQuery, IEnumerable<SubastaDto>>
{
    private readonly ISubastaService _subastaService;

    public GetSubastasBySubastadorQueryHandler(ISubastaService subastaService)
    {
        _subastaService = subastaService;
    }

    public async Task<IEnumerable<SubastaDto>> Handle(GetSubastasBySubastadorQuery request, CancellationToken cancellationToken)
    {
        return await _subastaService.GetBySubastadorIdAsync(request.SubastadorId);
    }
} 