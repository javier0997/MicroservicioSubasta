using MediatR;
using ProductoService.Application.Commands;
using ProductoService.Application.Services;

namespace ProductoService.Application.Handlers;

public class DeleteSubastaCommandHandler : IRequestHandler<DeleteSubastaCommand>
{
    private readonly ISubastaService _subastaService;

    public DeleteSubastaCommandHandler(ISubastaService subastaService)
    {
        _subastaService = subastaService;
    }

    public async Task Handle(DeleteSubastaCommand request, CancellationToken cancellationToken)
    {
        await _subastaService.DeleteAsync(request.Id);
    }
} 