﻿using Padutronics.Validation.Verifiers;
using System.Collections.Generic;

namespace Padutronics.Validation.Test.Verifiers;

internal sealed class EqualToVerifier<T> : IVerifier<T>
{
    private readonly T expectedValue;

    public EqualToVerifier(T expectedValue)
    {
        this.expectedValue = expectedValue;
    }

    public VerificationResult Verify(T value)
    {
        return EqualityComparer<T>.Default.Equals(value, expectedValue)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}