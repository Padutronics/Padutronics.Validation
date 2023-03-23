using System.Linq;

namespace Padutronics.Validation;

internal static class ValidationResults
{
    public static ValidationResult Success { get; } = new ValidationResult(errors: Enumerable.Empty<ValidationError>());
}