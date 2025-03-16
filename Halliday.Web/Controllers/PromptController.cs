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
        
        // TODO: Get parameters by having a model "label" each word in a prompt.
        // Each word can be classified such as "Dominic":"Person", or "Ohio":"Place".
        // We can then use these labels in an actions execute method.
        var result = action.Execute();
        return Results.Ok(action.ParseResponse(result));
    }
}