using Halliday.Application;
using Microsoft.AspNetCore.Mvc;

namespace Halliday.Web.Controllers;

[Route("api/v1/[controller]/[action]")]
public class TestController(TestService test) : Controller
{
    [HttpPost]
    public void Run() => test.Run();
}