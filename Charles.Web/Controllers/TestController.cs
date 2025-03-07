using Microsoft.AspNetCore.Mvc;

namespace Charles.Web.Controllers;

public class TestController : Controller
{
    [HttpPost]
    public string Hit([FromBody] string body)
    {
        return body;
    }
}