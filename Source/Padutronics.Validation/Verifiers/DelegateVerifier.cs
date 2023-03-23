using System;

namespace Padutronics.Validation.Verifiers;

internal sealed class DelegateVerifier<T> : IVerifier<T>
{
    private readonly Func<T, VerificationResult> verifyMethod;

    public DelegateVerifier(Func<T, VerificationResult> verifyMethod)
    {
        this.verifyMethod = verifyMethod;
    }

    public VerificationResult Verify(T value)
    {
        return verifyMethod(value);
    }
}