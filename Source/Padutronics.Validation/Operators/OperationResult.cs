using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Validation.Operators;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
internal sealed class OperationResult : IEquatable<OperationResult>
{
    public OperationResult(bool isSucceeded)
    {
        IsSucceeded = isSucceeded;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => IsSucceeded ? "Success" : "Failure";

    public bool IsFailed => !IsSucceeded;

    public bool IsSucceeded { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as OperationResult);
    }

    public bool Equals(OperationResult? other)
    {
        return other is not null && IsSucceeded == other.IsSucceeded;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IsSucceeded);
    }

    public static bool operator ==(OperationResult? left, OperationResult? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(OperationResult? left, OperationResult? right)
    {
        return !(left == right);
    }
}