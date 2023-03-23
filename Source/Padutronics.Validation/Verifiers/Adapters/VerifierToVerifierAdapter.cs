using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers.Adapters;

internal sealed class VerifierToVerifierAdapter<TTarget, TValue> : IVerifier<TTarget, TValue>
{
    private readonly IVerifier<TValue> verifier;

    public VerifierToVerifierAdapter(IVerifier<TValue> verifier)
    {
        this.verifier = verifier;
    }

    public VerificationResult Verify(TTarget target, TValue value)
    {
        return verifier.Verify(value);
    }

    public Task<VerificationResult> VerifyAsync(TTarget target, TValue value)
    {
        return verifier.VerifyAsync(value);
    }
}