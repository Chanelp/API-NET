namespace WebApiNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApiNet.Services;

[Route("api/[controller]")]
[ApiController]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    TareasContext dbcontext;
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, TareasContext db,ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Retornando saludo");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult Createdatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}