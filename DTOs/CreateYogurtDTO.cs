namespace miapi.DTOs;

public record CreateYogurtDTO
{
    public required string Codigo { get; set; }
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public required decimal Precio { get; set; }
    public required int Cantidad { get; set; }
    public required string Categoria { get; set; }
    public required string FechaExpiracion { get; set; }
}