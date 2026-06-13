namespace yogurtApi.Module.Yogurt.Dtos;

using System.ComponentModel.DataAnnotations;

public class UpdateYogurtDtos
{

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    public required string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
    public required string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo Precio es obligatorio.")]
    public required decimal Precio { get; set; }

    [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
    public required int Cantidad { get; set; }

    [Required(ErrorMessage = "El campo Categoria es obligatorio.")]
    public required string Categoria { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo FechaExpiracion es obligatorio.")]
    public required string FechaExpiracion { get; set; } = string.Empty;
}