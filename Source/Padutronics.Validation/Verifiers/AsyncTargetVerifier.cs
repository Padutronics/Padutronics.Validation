using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

public abstract class AsyncTargetVerifier<TTarget, TValue> : ITargetVerifier<TTarget, TValue>
{
    public VerificationResult Verify(TTarget target, TValue value)
    {
        return VerifyAsync(target, value).GetAwaiter().GetResult();
    }

    public abstract Task<VerificationResult> VerifyAsync(TTarget target, TValue value);
}