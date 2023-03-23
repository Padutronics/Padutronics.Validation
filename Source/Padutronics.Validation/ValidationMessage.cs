using Padutronics.Diagnostics.Debugging;
using Padutronics.Extensions.System;
using System;
using System.Diagnostics;

namespace Padutronics.Validation;

[DebuggerDisplay(DebuggerDisplayValues.ToStringWithQuotes)]
public sealed class ValidationMessage : IEquatable<ValidationMessage>
{
    private readonly string value;

    public ValidationMessage(string value)
    {
        if (value.IsEmpty())
        {
            throw new ArgumentException("Validation message cannot be empty.", nameof(value));
        }

        this.value = value;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ValidationMessage);
    }

    public bool Equals(ValidationMessage? other)
    {
        return other is not null && value == other.value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(value);
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public static bool operator ==(ValidationMessage? left, ValidationMessage? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(ValidationMessage? left, ValidationMessage? right)
    {
        return !(left == right);
    }
}