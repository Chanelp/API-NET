using Microsoft.AspNetCore.Mvc;
using WebApiNet.Services;
using WebApiNet.Models;

namespace WebApiNet.Controllers;

[Route("api[controller]")]
public class TareasController : ControllerBase
{
    protected readonly ITareasService _tareasService;

    public TareasController(ITareasService service)
    {
        _tareasService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_tareasService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        _tareasService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Tarea tarea)
    {
        _tareasService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _tareasService.Delete(id);
        return Ok();
    }

}