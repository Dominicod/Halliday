using Halliday.Domain.Common.Interfaces;

namespace Halliday.Domain.ValueObjects;

public record ModelOutput(string Value, float[] Score) : IValueObject;