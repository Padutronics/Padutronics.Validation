using System;

namespace Padutronics.Validation.Verifiers;

public sealed class DelegateVerifier<TTarget, TValue> : Verifier<TTarget, TValue>
{
    private readonly Func<TTarget, TValue, VerificationResult> verifyMethod;

    public DelegateVerifier(Func<TTarget, TValue, VerificationResult> verifyMethod)
    {
        this.verifyMethod = verifyMethod;
    }

    public override VerificationResult Verify(TTarget target, TValue value)
    {
        return verifyMethod(target, value);
    }
}