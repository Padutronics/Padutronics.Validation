namespace Padutronics.Validation.Verifiers.Adapters;

internal sealed class VerifierToTargetVerifierAdapter<TTarget, TValue> : ITargetVerifier<TTarget, TValue>
{
    private readonly IVerifier<TValue> verifier;

    public VerifierToTargetVerifierAdapter(IVerifier<TValue> verifier)
    {
        this.verifier = verifier;
    }

    public VerificationResult Verify(TTarget target, TValue value)
    {
        return verifier.Verify(value);
    }
}