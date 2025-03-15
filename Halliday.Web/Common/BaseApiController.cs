using Microsoft.AspNetCore.Mvc;

namespace Halliday.Web.Common;

[ApiController]
[Route("[controller]/[action]")]
public abstract class BaseApiController : ControllerBase;