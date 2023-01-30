namespace WebApiNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApiNet.Services;

[Route("api/[controller]")]
[ApiController]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldService = helloWorld;
    }

    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}