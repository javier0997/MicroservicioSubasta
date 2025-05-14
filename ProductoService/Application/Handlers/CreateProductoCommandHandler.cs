using AutoMapper;
using MassTransit;
using MediatR;
using ProductoService.Application.Commands;
using ProductoService.Application.DTOs;
using ProductoService.Application.Events;
using ProductoService.Domain.Entities;
using ProductoService.Infrastructure.Data.PostgresDb;

namespace ProductoService.Application.Handlers;

public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, ProductoDto>
{
    private readonly ProductoWriteDbContext _writeContext;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateProductoCommandHandler(
        ProductoWriteDbContext writeContext,
        IMapper mapper,
        IPublishEndpoint publishEndpoint)
    {
        _writeContext = writeContext;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<ProductoDto> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
    {
        var producto = new Producto
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            PrecioBase = request.PrecioBase,
            Categoria = request.Categoria,
            ImagenUrl = request.ImagenUrl,
            SubastadorId = request.SubastadorId,
            Estado = "Disponible",
            FechaCreacion = DateTime.UtcNow,
            FechaActualizacion = DateTime.UtcNow
        };

        _writeContext.Productos.Add(producto);
        await _writeContext.SaveChangesAsync(cancellationToken);

        // Publicar evento
        await _publishEndpoint.Publish(new ProductoCreatedEvent
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            PrecioBase = producto.PrecioBase,
            Estado = producto.Estado,
            Categoria = producto.Categoria,
            ImagenUrl = producto.ImagenUrl,
            FechaCreacion = producto.FechaCreacion,
            SubastadorId = producto.SubastadorId
        }, cancellationToken);

        return _mapper.Map<ProductoDto>(producto);
    }
} 