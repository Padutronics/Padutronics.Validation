namespace Padutronics.Validation.Verifiers;

public interface ITargetVerifier<in TTarget, in TValue>
{
    VerificationResult Verify(TTarget target, TValue value);
}