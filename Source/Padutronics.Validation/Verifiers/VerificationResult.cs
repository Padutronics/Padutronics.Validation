using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Validation.Verifiers;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class VerificationResult : IEquatable<VerificationResult>
{
    public VerificationResult(bool isSucceeded)
    {
        IsSucceeded = isSucceeded;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => IsSucceeded ? "Success" : "Failure";

    public bool IsFailed => !IsSucceeded;

    public bool IsSucceeded { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as VerificationResult);
    }

    public bool Equals(VerificationResult? other)
    {
        return other is not null && IsSucceeded == other.IsSucceeded;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IsSucceeded);
    }

    public static bool operator ==(VerificationResult? left, VerificationResult? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(VerificationResult? left, VerificationResult? right)
    {
        return !(left == right);
    }
}