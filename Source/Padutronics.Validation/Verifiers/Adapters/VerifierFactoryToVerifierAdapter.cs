using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers.Adapters;

public sealed class VerifierFactoryToVerifierAdapter<TTarget, TValue> : IVerifier<TTarget, TValue>
{
    private readonly VerifierFactory<TTarget, TValue> verifierFactory;

    public VerifierFactoryToVerifierAdapter(VerifierFactory<TTarget, TValue> verifierFactory)
    {
        this.verifierFactory = verifierFactory;
    }

    public VerificationResult Verify(TTarget target, TValue value)
    {
        IVerifier<TValue> verifier = verifierFactory(target);

        return verifier.Verify(value);
    }

    public Task<VerificationResult> VerifyAsync(TTarget target, TValue value)
    {
        IVerifier<TValue> verifier = verifierFactory(target);

        return verifier.VerifyAsync(value);
    }
}