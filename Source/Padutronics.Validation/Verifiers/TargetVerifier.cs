using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

public abstract class TargetVerifier<TTarget, TValue> : ITargetVerifier<TTarget, TValue>
{
    public abstract VerificationResult Verify(TTarget target, TValue value);

    public Task<VerificationResult> VerifyAsync(TTarget target, TValue value)
    {
        return Task.FromResult(Verify(target, value));
    }
}