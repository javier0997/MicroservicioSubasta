namespace ProductoService.Domain.Entities;

public class Subasta
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
    public decimal PrecioBase { get; set; }
    public decimal IncrementoMinimo { get; set; }
    public decimal? PrecioReserva { get; set; }
    public string Tipo { get; set; } = string.Empty; // Ej: "Inglesa", "Holandesa"
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Estado { get; set; } = string.Empty; // Pending, Active, Ended, Canceled, Completed
    public int SubastadorId { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
} 