using Halliday.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Halliday.Web.Controllers;

[ApiController]
public class PromptController : Controller
{
    public IResult Answer(UserPrompt request)
    {
        return Results.Ok(new UserAnswer(string.Empty));
    }
}