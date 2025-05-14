using MediatR;
using ProductoService.Application.DTOs;
using ProductoService.Application.Queries;
using ProductoService.Application.Services;

namespace ProductoService.Application.Handlers;

public class GetSubastaByIdQueryHandler : IRequestHandler<GetSubastaByIdQuery, SubastaDto?>
{
    private readonly ISubastaService _subastaService;

    public GetSubastaByIdQueryHandler(ISubastaService subastaService)
    {
        _subastaService = subastaService;
    }

    public async Task<SubastaDto?> Handle(GetSubastaByIdQuery request, CancellationToken cancellationToken)
    {
        return await _subastaService.GetByIdAsync(request.Id);
    }
} 