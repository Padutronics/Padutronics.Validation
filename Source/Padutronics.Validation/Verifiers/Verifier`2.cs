using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

public abstract class Verifier<TTarget, TValue> : IVerifier<TTarget, TValue>
{
    public abstract VerificationResult Verify(TTarget target, TValue value);

    public Task<VerificationResult> VerifyAsync(TTarget target, TValue value)
    {
        return Task.FromResult(Verify(target, value));
    }
}