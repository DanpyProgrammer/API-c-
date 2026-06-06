using System;
using miapi.DTOs;
using miapi.Models;
using System.ComponentModel.DataAnnotations;


var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<Producto> productos = [

    new(){
        Id = 1,
        Codigo = "YOG001",
        Nombre = "Yogurt Natural",
        Descripcion = "Yogurt natural sin azúcar",
        Precio = 1.99m,
        Cantidad = 100,
        Categoria = "Lácteos",
        FechaExpiracion = "2027-03-04"
    },
    new(){
        Id = 2,
        Codigo = "YOG002",
        Nombre = "Yogurt de Fresa",
        Descripcion = "Yogurt con sabor a fresa",
        Precio = 2.49m,
        Cantidad = 50,
        Categoria = "Lácteos",
        FechaExpiracion = "2027-03-04"
    },
    new(){
        Id = 3,
        Codigo = "YOG003",
        Nombre = "Yogurt de Vainilla",
        Descripcion = "Yogurt con sabor a vainilla",
        Precio = 2.49m,     
        Cantidad = 50,
        Categoria = "Lácteos",
        FechaExpiracion = "2027-03-04"
    }
];

app.MapPost( "/yogurts", (CreateYogurtDTO product) =>
{
      // Validar los atributos [Required]
    var validationResults = new List<ValidationResult>();
    var context = new ValidationContext(product);
    if (Validator.TryValidateObject(product, context, validationResults, true))
    {
        return Results.Created("/yogurts", product);
    }

    return Results.BadRequest("Datos inválidos: Todos los campos son requeridos");
    
});


app.MapGet("/yogurt", () =>
{
   return Results.Ok(productos);
});


app.MapGet( "/yogurt/{Id}", (int Id) =>
{
    return productos.FirstOrDefault(p => p.Id == Id) is { } producto ? Results.Ok(producto) : Results.NotFound("Producto no encontrado con el ID proporcionado");
});

app.MapGet("yogu", (string? Nombre, string? Codigo) =>
{
    // 1️⃣ Validar si no llegó ningún parámetro
    if (string.IsNullOrEmpty(Nombre) && string.IsNullOrEmpty(Codigo))
        return Results.BadRequest("Debe proporcionar al menos un parámetro de búsqueda (Nombre o Codigo)");

    // 2️⃣ Comenzamos con todos los productos
    var resultado = productos.AsEnumerable();

    // 3️⃣ Filtramos según los parámetros que llegaron
    if (!string.IsNullOrEmpty(Nombre))
        resultado = resultado.Where(p => p.Nombre.Contains(Nombre, StringComparison.OrdinalIgnoreCase));

    if (!string.IsNullOrEmpty(Codigo))
        resultado = resultado.Where(p => p.Codigo.Contains(Codigo, StringComparison.OrdinalIgnoreCase));

    return resultado.Any() ? Results.Ok(resultado.ToList()) : Results.NotFound("No se encontraron productos que coincidan con los criterios de búsqueda");

    
});

app.MapDelete("/yogurt/{Id}", (int Id) =>
{
    return productos.RemoveAll(p => p.Id == Id) > 0 ? Results.Ok("Producto eliminado exitosamente") : Results.NotFound("Producto no encontrado para eliminar");
});

app.MapPatch("/yogurt/{Id}", (int Id, PatchYogurtDTO product) =>
{
    var yogurt = productos.FirstOrDefault(p => p.Id == Id);

    if (yogurt is null)
        return Results.NotFound("Producto no encontrado para actualizar");

    if (product.Nombre is not null)
        yogurt.Nombre = product.Nombre;

    if (product.Descripcion is not null)
        yogurt.Descripcion = product.Descripcion;

    if (product.Precio is not null)
    yogurt.Precio = product.Precio.Value;

    if (product.Cantidad is not null)
    yogurt.Cantidad = product.Cantidad.Value;

    if (product.Categoria is not null)
        yogurt.Categoria = product.Categoria;

    if (product.FechaExpiracion is not null)
        yogurt.FechaExpiracion = product.FechaExpiracion;

    return Results.Ok(new { message = "Producto actualizado parcialmente", data = yogurt});
    


});

app.MapPut("/yogurt/{Id}", (int Id, UpdateYogurtDTO product) =>
{
    if (product is null)
        return Results.BadRequest("El body no puede estar vacío");

    if (string.IsNullOrWhiteSpace(product.Nombre))
        return Results.BadRequest("El nombre es obligatorio");

    if (product.Precio <= 0)
        return Results.BadRequest("El precio debe ser mayor que 0");

    if (product.Cantidad < 0)
        return Results.BadRequest("La cantidad no puede ser negativa");

    if (string.IsNullOrWhiteSpace(product.Categoria))
        return Results.BadRequest("La categoría es obligatoria");

    if (product.FechaExpiracion == default)
        return Results.BadRequest("Fecha de expiración inválida");

    var yogurt = productos.FirstOrDefault(p => p.Id == Id);

    if (yogurt is null)
        return Results.NotFound("Producto no encontrado para actualizar");

    yogurt.Nombre = product.Nombre;
    yogurt.Descripcion = product.Descripcion;
    yogurt.Precio = product.Precio;
    yogurt.Cantidad = product.Cantidad;
    yogurt.Categoria = product.Categoria;
    yogurt.FechaExpiracion = product.FechaExpiracion;

    return Results.Ok(new
    {
        message = "Producto actualizado completamente", data = yogurt
    });
});
app.Run();

 