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

    
}