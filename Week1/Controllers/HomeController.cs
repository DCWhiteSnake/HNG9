using Microsoft.AspNetCore.Mvc;

namespace Week1.Controllers;


[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private static readonly ResponseModel _RESPONSE_ = ResponseModel.ResponseModelInstance;


    [HttpGet("/get")]
    public IActionResult Get()
    {
        return Ok(_RESPONSE_);
    }
}
