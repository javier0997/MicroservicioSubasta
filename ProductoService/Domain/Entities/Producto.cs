namespace ProductoService.Domain.Entities;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int PropietarioId { get; set; } // Subastador
} 