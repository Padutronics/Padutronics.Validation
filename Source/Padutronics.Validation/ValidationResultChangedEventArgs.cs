using System;

namespace Padutronics.Validation;

public sealed class ValidationResultChangedEventArgs : EventArgs
{
    public ValidationResultChangedEventArgs(string propertyName, ValidationResult result)
    {
        PropertyName = propertyName;
        Result = result;
    }

    public string PropertyName { get; }

    public ValidationResult Result { get; }
}