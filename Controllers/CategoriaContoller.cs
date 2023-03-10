using Microsoft.AspNetCore.Mvc;
using WebApiNet.Services;
using WebApiNet.Models;

namespace WebApiNet.Controllers;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    // Recibir el servicio de Categoria
    protected readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService service)
    {
        _categoriaService = service;
    }

    // Endpoints para devolver la información

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        _categoriaService.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        _categoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _categoriaService.Delete(id);
        return Ok();
    }

}