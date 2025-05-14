using MediatR;
using ProductoService.Application.Commands;
using ProductoService.Application.DTOs;
using ProductoService.Application.Services;

namespace ProductoService.Application.Handlers;

public class CreateSubastaCommandHandler : IRequestHandler<CreateSubastaCommand, SubastaDto>
{
    private readonly ISubastaService _subastaService;

    public CreateSubastaCommandHandler(ISubastaService subastaService)
    {
        _subastaService = subastaService;
    }

    public async Task<SubastaDto> Handle(CreateSubastaCommand request, CancellationToken cancellationToken)
    {
        return await _subastaService.CreateAsync(request.Subasta);
    }
} 