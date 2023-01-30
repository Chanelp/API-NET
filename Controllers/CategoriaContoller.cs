using Microsoft.AspNetCore.Mvc;
using WebApiNet.Services;
using WebApiNet.Models;

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

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        categoriaService.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.Delete(id);
        return Ok();
    }

}