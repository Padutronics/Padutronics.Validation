using Padutronics.Diagnostics.Debugging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Padutronics.Validation;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class ValidationError
{
    public ValidationError(string propertyName, IEnumerable<ValidationMessage> messages)
    {
        Messages = messages;
        PropertyName = propertyName;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"PropertyName = {PropertyName}";

    public IEnumerable<ValidationMessage> Messages { get; }

    public string PropertyName { get; }
}