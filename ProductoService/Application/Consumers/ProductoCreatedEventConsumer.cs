using MassTransit;
using ProductoService.Application.Events;
using ProductoService.Domain.Entities;
using ProductoService.Infrastructure.Data.MongoDb;

namespace ProductoService.Application.Consumers;

public class ProductoCreatedEventConsumer : IConsumer<ProductoCreatedEvent>
{
    private readonly ProductoReadDbContext _readContext;

    public ProductoCreatedEventConsumer(ProductoReadDbContext readContext)
    {
        _readContext = readContext;
    }

    public async Task Consume(ConsumeContext<ProductoCreatedEvent> context)
    {
        var evento = context.Message;
        var producto = new Producto
        {
            Id = evento.Id,
            Nombre = evento.Nombre,
            Descripcion = evento.Descripcion,
            PrecioBase = evento.PrecioBase,
            Estado = evento.Estado,
            Categoria = evento.Categoria,
            ImagenUrl = evento.ImagenUrl,
            FechaCreacion = evento.FechaCreacion,
            FechaActualizacion = evento.FechaCreacion,
            SubastadorId = evento.SubastadorId
        };

        await _readContext.Productos.InsertOneAsync(producto);
    }
} 