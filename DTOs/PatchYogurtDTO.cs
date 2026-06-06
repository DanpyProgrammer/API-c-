namespace miapi.DTOs;

public record PatchYogurtDTO
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public decimal? Precio { get; set; }
    public int? Cantidad { get; set; }
    public string? Categoria { get; set; }
    public string? FechaExpiracion { get; set; }
}