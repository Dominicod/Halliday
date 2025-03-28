﻿using Halliday.AI;
using Halliday.AI.Common;
using Halliday.AI.Models.ActionClassificationModel;

if (args.Length is 0)
{
    Console.WriteLine("No arguments were provided.");
    Console.WriteLine("Usage example: Halliday.AI.exe --train --model=action_classification");
    return;
}

var actionArg = args.FirstOrDefault(i => i.Equals("--train") || i.Equals("--eval"));
var modelArg = args.FirstOrDefault(i => i.StartsWith("--model="));


IModel model = modelArg switch
{
    "--model=action_classification" => new ActionClassificationBaseModel("Models/ActionClassificationModel/ActionClassificationModel.mlnet"),
    _ => throw new ArgumentException("Invalid model argument.")
};

switch (actionArg)
{
    case "--train":
        Console.WriteLine("Training...");
        break;
    case "--eval":
        Console.WriteLine("Evaluating...");
        var labelArgument = args.FirstOrDefault(i => i.StartsWith("--label="));
        
        if (labelArgument is null)
        {
            Console.WriteLine("No label argument was provided.");
            Console.WriteLine("Usage example: Halliday.AI.exe --eval --model=action_classification --label=col0");
            return;
        }
        
        model.Evaluate(labelArgument);
        break;
    default:
        Console.WriteLine("Invalid argument.");
        break;
}