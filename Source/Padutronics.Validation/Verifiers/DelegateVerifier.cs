using System;

namespace Padutronics.Validation.Verifiers;

public sealed class DelegateVerifier<T> : Verifier<T>
{
    private readonly Func<T, VerificationResult> verifyMethod;

    public DelegateVerifier(Func<T, VerificationResult> verifyMethod)
    {
        this.verifyMethod = verifyMethod;
    }

    public override VerificationResult Verify(T value)
    {
        return verifyMethod(value);
    }
}