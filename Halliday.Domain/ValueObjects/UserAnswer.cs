using Halliday.Domain.Common.Interfaces;

namespace Halliday.Domain.ValueObjects;

public record UserAnswer(string Answer) : IValueObject;