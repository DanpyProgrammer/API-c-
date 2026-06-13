using Microsoft.AspNetCore.Mvc;
using yogurtApi.Module.Yogurt.Dtos;
using yogurtApi.Module.Yogurt.Entities;
using yogurtApi.Module.Yogurt.Services;


namespace yogurtApi.Module.Yogurt.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class YogurtController(YogurtService yogurtService) : ControllerBase
{
    private readonly YogurtService yogurtService = yogurtService;

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(new
        {
            message = "Lista de yogures",
            yogures = yogurtService.FindAll()
        });
    }

    [HttpGet("{uuid}")]
    public IActionResult FindOne(Guid uuid)
    {
        YogurtEntity? yogurt = yogurtService.FindOne(uuid);
        
        if (yogurt == null)
        {
            return NotFound(new { message = "Yogurt no encontrado" });
        }
        return Ok(new
        {
            message = "Yogurt encontrado",
            yogurt
        });
    }

    [HttpPost]
    public IActionResult Create(CreateYogurtDtos createYogurtDtos)
    {
        return Ok(yogurtService.Create(createYogurtDtos));
    }

    [HttpPatch("{uuid}")]
    public IActionResult Update(Guid uuid, UpdateYogurtDtos updateYogurtDtos)
    {
        YogurtEntity? yogurtUpdate = yogurtService.Update(uuid, updateYogurtDtos);
        if (yogurtUpdate == null)
        {
            return NotFound(new { message = "No se encontró el yogurt a actualizar" });
        }
        return Ok(new
        {
            message = "Yogurt actualizado correctamente",
            yogurt = yogurtUpdate
        });
    }

    [HttpDelete("{uuid}")]
    public IActionResult Delete(Guid uuid)
    {
        bool deleted = yogurtService.Delete(uuid);
        if (!deleted)
        {
            return NotFound(new { message = "No se encontró el yogurt a eliminar" });
        }
        return Ok(new { message = "Yogurt eliminado correctamente" });
    }
}
