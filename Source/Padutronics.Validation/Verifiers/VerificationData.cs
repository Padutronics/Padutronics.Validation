using System;

namespace Padutronics.Validation.Verifiers;

internal sealed class VerificationData<TTarget, TValue>
{
    public VerificationData(ITargetVerifier<TTarget, TValue> verifier, Predicate<TTarget> verificationCondition, bool isVerificationNegated)
    {
        IsVerificationNegated = isVerificationNegated;
        VerificationCondition = verificationCondition;
        Verifier = verifier;
    }

    public bool IsVerificationNegated { get; }

    public Predicate<TTarget> VerificationCondition { get; }

    public ITargetVerifier<TTarget, TValue> Verifier { get; }
}