using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Validation.Operators.Strategires;

[DebuggerDisplay(DebuggerDisplayValues.ToStringWithoutQuotes)]
public sealed class ExpectedCount : IComparable<ExpectedCount>, IEquatable<ExpectedCount>
{
    private readonly int value;

    public ExpectedCount(int value)
    {
        this.value = value;
    }

    public int CompareTo(ExpectedCount? other)
    {
        return value.CompareTo(other?.value);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ExpectedCount);
    }

    public bool Equals(ExpectedCount? other)
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

    public static bool operator ==(ExpectedCount? left, ExpectedCount? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(ExpectedCount? left, ExpectedCount? right)
    {
        return !(left == right);
    }

    public static bool operator >=(ExpectedCount? left, ExpectedCount? right)
    {
        return right <= left;
    }

    public static bool operator <=(ExpectedCount? left, ExpectedCount? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(ExpectedCount? left, ExpectedCount? right)
    {
        return right < left;
    }

    public static bool operator <(ExpectedCount? left, ExpectedCount? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static implicit operator ExpectedCount(int value)
    {
        return new ExpectedCount(value);
    }
}