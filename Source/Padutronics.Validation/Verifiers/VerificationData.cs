using System;

namespace Padutronics.Validation.Verifiers;

internal sealed class VerificationData<TTarget, TValue>
{
    public VerificationData(IVerifier<TTarget, TValue> verifier, Predicate<TTarget> verificationCondition, bool isVerificationNegated)
    {
        IsVerificationNegated = isVerificationNegated;
        VerificationCondition = verificationCondition;
        Verifier = verifier;
    }

    public bool IsVerificationNegated { get; }

    public Predicate<TTarget> VerificationCondition { get; }

    public IVerifier<TTarget, TValue> Verifier { get; }
}