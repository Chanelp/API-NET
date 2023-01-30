namespace WebApiNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApiNet.Services;

[Route("api/[controller]")]
[ApiController]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    private readonly ILogger<HelloWorldController> _logger;
    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        helloWorldService = helloWorld;
    }

    public IActionResult Get()
    {
        _logger.LogInformation("Retornando saludo");
        return Ok(helloWorldService.GetHelloWorld());
    }
}