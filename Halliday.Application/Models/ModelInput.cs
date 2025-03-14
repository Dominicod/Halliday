namespace Halliday.Application.Models;

public record ModelInput(string Value)
{
    public static implicit operator ModelInput(string value) => new(value);
    
    public static implicit operator string(ModelInput model) => model.Value;
}