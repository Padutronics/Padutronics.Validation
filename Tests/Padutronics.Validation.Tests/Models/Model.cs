﻿namespace Padutronics.Validation.Test.Models;

internal sealed class Model<T>
{
    public Model(T value)
    {
        Value = value;
    }

    public T Value { get; }
}