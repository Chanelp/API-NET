using Microsoft.AspNetCore.Mvc;
using WebApiNet.Services;
using WebApiNet.Models;

namespace WebApiNet.Controllers;

[Route("api[controller]")]
public class TareasController : ControllerBase
{
    TareasService tareasService;

    public TareasController(TareasService service)
    {
        tareasService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareasService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareasService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Tarea tarea)
    {
        tareasService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareasService.Delete(id);
        return Ok();
    }

}