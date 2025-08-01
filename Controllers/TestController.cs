using Microsoft.AspNetCore.Mvc;

namespace realbricks_user_dotnet_backend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TestController : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new {Name = "Elon Musk", Age = 21});
    }
}