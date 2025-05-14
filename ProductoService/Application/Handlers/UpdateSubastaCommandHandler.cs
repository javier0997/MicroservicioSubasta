using MediatR;
using ProductoService.Application.Commands;
using ProductoService.Application.DTOs;
using ProductoService.Application.Services;

namespace ProductoService.Application.Handlers;

public class UpdateSubastaCommandHandler : IRequestHandler<UpdateSubastaCommand, SubastaDto>
{
    private readonly ISubastaService _subastaService;

    public UpdateSubastaCommandHandler(ISubastaService subastaService)
    {
        _subastaService = subastaService;
    }

    public async Task<SubastaDto> Handle(UpdateSubastaCommand request, CancellationToken cancellationToken)
    {
        return await _subastaService.UpdateAsync(request.Id, request.Subasta);
    }
} 