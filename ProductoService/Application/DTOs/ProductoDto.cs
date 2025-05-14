namespace ProductoService.Application.DTOs;

public class ProductoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int PropietarioId { get; set; }
}

public class CreateProductoDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
    public int PropietarioId { get; set; }
}

public class UpdateProductoDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
} 