using Halliday.Domain.Common.Interfaces;

namespace Halliday.Domain.ValueObjects;

public record UserPrompt(string Prompt) : IValueObject;