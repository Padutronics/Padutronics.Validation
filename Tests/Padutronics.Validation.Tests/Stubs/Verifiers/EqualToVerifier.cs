using Padutronics.Validation.Verifiers;
using System.Collections.Generic;

namespace Padutronics.Validation.Test.Stubs.Verifiers;

internal sealed class EqualToVerifier<T> : Verifier<T>
{
    private readonly T expectedValue;

    public EqualToVerifier(T expectedValue)
    {
        this.expectedValue = expectedValue;
    }

    public override VerificationResult Verify(T value)
    {
        return EqualityComparer<T>.Default.Equals(value, expectedValue)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}