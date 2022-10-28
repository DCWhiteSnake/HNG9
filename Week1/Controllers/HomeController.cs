using Microsoft.AspNetCore.Mvc;

namespace Week1.Controllers;


[ApiController]
[Route("api")]
public class HomeController : ControllerBase
{
    private static readonly ResponseModel _RESPONSE_ = ResponseModel.ResponseModelInstance;


    [HttpGet]
    public IActionResult Get()
    {

        HttpContext.Response.Headers.Add("access-control-allow-origin", "*");
        return Ok(_RESPONSE_);
    }
}
