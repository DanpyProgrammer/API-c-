namespace yogurtApi.Module.Yogurt.Services;

using yogurtApi.Module.Yogurt.Entities; 
using yogurtApi.Module.Yogurt.Dtos;

public class YogurtService
{
    private readonly static List<YogurtEntity> yogurts = [
        new YogurtEntity
        {
            Codigo = "Y001",
            Nombre = "Yogurt Natural",
            Descripcion = "Yogurt natural sin azúcar",
            Precio = 1.99m,
            Cantidad = 100,
            Categoria = "Natural",
            FechaExpiracion = "2024-12-31"
        },
        new YogurtEntity
        {
            Codigo = "Y002",
            Nombre = "Yogurt de Fresa",
            Descripcion = "Yogurt con sabor a fresa",
            Precio = 2.49m,
            Cantidad = 50,
            Categoria = "Saborizado",
            FechaExpiracion = "2024-11-30"
        },
        new YogurtEntity
        {
            Codigo = "Y003",
            Nombre = "Yogurt Griego",
            Descripcion = "Yogurt griego sin azúcar",
            Precio = 3.99m,
            Cantidad = 30,
            Categoria = "Griego",
            FechaExpiracion = "2024-10-31"
        }
    ];

    public List<YogurtEntity> FindAll()
    {
        return yogurts;
    }
    
    public YogurtEntity? FindOne(Guid uuid)
    {
        YogurtEntity? yogurt = yogurts.FirstOrDefault(y => y.uuid == uuid);
        return yogurt;
    }

    public YogurtEntity Create(CreateYogurtDtos createYogurtDtos)
    {
        YogurtEntity yogurt = new YogurtEntity
        {
            Codigo = createYogurtDtos.Codigo,
            Nombre = createYogurtDtos.Nombre,
            Descripcion = createYogurtDtos.Descripcion,
            Precio = createYogurtDtos.Precio,
            Cantidad = createYogurtDtos.Cantidad,
            Categoria = createYogurtDtos.Categoria,
            FechaExpiracion = createYogurtDtos.FechaExpiracion
        };

        yogurts.Add(yogurt);
        return yogurt;
    }

    public YogurtEntity? Update(Guid uuid, UpdateYogurtDtos updateYogurtDtos)
    {
        YogurtEntity? yogurt = yogurts.FirstOrDefault(y => y.uuid == uuid);
        if (yogurt is null) return null;

        yogurt.Nombre = updateYogurtDtos.Nombre;
        yogurt.Descripcion = updateYogurtDtos.Descripcion;
        yogurt.Precio = updateYogurtDtos.Precio;
        yogurt.Cantidad = updateYogurtDtos.Cantidad;
        yogurt.Categoria = updateYogurtDtos.Categoria;
        yogurt.FechaExpiracion = updateYogurtDtos.FechaExpiracion;

        return yogurt;
    }

    public bool Delete(Guid uuid)
    {
        YogurtEntity? yogurt = yogurts.FirstOrDefault(y => y.uuid == uuid);
        if (yogurt is null) return false;

        yogurts.Remove(yogurt);
        return true;
    }
    
}