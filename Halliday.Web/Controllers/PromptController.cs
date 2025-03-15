using Halliday.Application.Factories;
using Halliday.Application.Interfaces;
using Halliday.Domain.ValueObjects;
using Halliday.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace Halliday.Web.Controllers;

public class PromptController(ActionFactory actionFactory, IActionClassificationService classificationService) : BaseApiController
{
    [HttpPost]
    public IResult Answer(UserPrompt request)
    {
        var classification = classificationService.ClassifyAction(request.Prompt);
        var action = actionFactory.Get(classification.Value);
        
        if (action is null)
            throw new ArgumentNullException(nameof(request));
        
        var result = action.Execute();
        return Results.Ok(action.ParseResponse(result));
    }
}