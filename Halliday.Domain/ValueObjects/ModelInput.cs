using Halliday.Domain.Common.Interfaces;

namespace Halliday.Domain.ValueObjects;

public record ModelInput(string Value) : IValueObject
{
    public static implicit operator ModelInput(string value) => new(value);
    
    public static implicit operator string(ModelInput model) => model.Value;
}