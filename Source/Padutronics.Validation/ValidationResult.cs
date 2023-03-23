using Padutronics.Diagnostics.Debugging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Padutronics.Validation;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class ValidationResult
{
    private readonly IReadOnlyDictionary<string, IEnumerable<ValidationMessage>> propertyNameToMessagesMappings;

    public ValidationResult(IEnumerable<ValidationError> errors)
    {
        propertyNameToMessagesMappings = errors
            .GroupBy(error => error.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => (IEnumerable<ValidationMessage>)group
                    .SelectMany(error => error.Messages)
                    .ToList()
            );
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => IsSucceeded ? "Success" : "Failure";

    public bool IsFailed => propertyNameToMessagesMappings.Any();

    public bool IsSucceeded => !IsFailed;

    public IEnumerable<string> PropertyNames => propertyNameToMessagesMappings.Keys;

    public bool ContainsError(string propertyName)
    {
        return propertyNameToMessagesMappings.ContainsKey(propertyName);
    }

    public IEnumerable<ValidationError> GetErrors()
    {
        return propertyNameToMessagesMappings
            .Select(
                propertyNameToMessagesMapping => new ValidationError(
                    propertyName: propertyNameToMessagesMapping.Key,
                    messages: propertyNameToMessagesMapping.Value
                )
            )
            .ToList();
    }

    public bool TryGetError(string propertyName, [NotNullWhen(true)] out ValidationError? error)
    {
        if (propertyNameToMessagesMappings.TryGetValue(propertyName, out IEnumerable<ValidationMessage>? messages))
        {
            error = new ValidationError(propertyName, messages);
        }
        else
        {
            error = null;
        }

        return error is not null;
    }
}