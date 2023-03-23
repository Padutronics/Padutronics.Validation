using System;

namespace Padutronics.Validation.Verifiers;

public sealed class DelegateTargetVerifier<TTarget, TValue> : TargetVerifier<TTarget, TValue>
{
    private readonly Func<TTarget, TValue, VerificationResult> verifyMethod;

    public DelegateTargetVerifier(Func<TTarget, TValue, VerificationResult> verifyMethod)
    {
        this.verifyMethod = verifyMethod;
    }

    public override VerificationResult Verify(TTarget target, TValue value)
    {
        return verifyMethod(target, value);
    }
}