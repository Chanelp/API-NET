using Microsoft.AspNetCore.Mvc;
using WebApiNet.Services;

namespace WebApiNet.Controllers;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    // Recibir el servicio de Categoria
    ICategoriaService categoriaService;

    public CategoriaController(CategoriaService service)
    {
        categoriaService = service;
    }

    // Endpoints para devolver la información

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.Get());
    }

}