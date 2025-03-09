using Microsoft.AspNetCore.Mvc;

namespace Halliday.Web.Controllers;

public class TestController : Controller
{
    [HttpPost]
    public string Hit([FromBody] string body)
    {
        return body;
    }
}