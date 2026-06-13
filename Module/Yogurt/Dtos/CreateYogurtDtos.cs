using System.ComponentModel.DataAnnotations;

namespace yogurtApi.Module.Yogurt.Dtos;

public class CreateYogurtDtos
{
    [Required(ErrorMessage = "El campo Codigo es obligatorio.")]
    [MinLength(6, ErrorMessage = "El campo Codigo debe tener al menos 6 caracteres.")]
    public required string Codigo { get; set; } = string.Empty;

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