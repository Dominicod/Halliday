using Halliday.Application;
using Microsoft.AspNetCore.Mvc;

namespace Halliday.Web.Controllers;

public class TestController(TestService test) : Controller
{
    [HttpPost]
    [Route("[controller]/run")]
    public void Run() => test.Run();
}