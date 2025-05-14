namespace ProductoService.Application.DTOs;

public class SubastaDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public ProductoDto? Producto { get; set; }
    public decimal PrecioBase { get; set; }
    public decimal IncrementoMinimo { get; set; }
    public decimal? PrecioReserva { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Estado { get; set; } = string.Empty;
    public int SubastadorId { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
}

public class CreateSubastaDto
{
    public int ProductoId { get; set; }
    public decimal PrecioBase { get; set; }
    public decimal IncrementoMinimo { get; set; }
    public decimal? PrecioReserva { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int SubastadorId { get; set; }
}

public class UpdateSubastaDto
{
    public decimal? PrecioBase { get; set; }
    public decimal? IncrementoMinimo { get; set; }
    public decimal? PrecioReserva { get; set; }
    public string? Tipo { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? Estado { get; set; }
} 