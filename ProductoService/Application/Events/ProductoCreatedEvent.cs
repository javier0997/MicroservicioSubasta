namespace ProductoService.Application.Events;

public record ProductoCreatedEvent
{
    public int Id { get; init; }
    public string Nombre { get; init; } = string.Empty;
    public string Descripcion { get; init; } = string.Empty;
    public decimal PrecioBase { get; init; }
    public string Estado { get; init; } = string.Empty;
    public string Categoria { get; init; } = string.Empty;
    public string? ImagenUrl { get; init; }
    public DateTime FechaCreacion { get; init; }
    public int SubastadorId { get; init; }
} 