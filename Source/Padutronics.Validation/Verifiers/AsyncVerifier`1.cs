using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

public abstract class AsyncVerifier<T> : IVerifier<T>
{
    public VerificationResult Verify(T value)
    {
        return VerifyAsync(value).GetAwaiter().GetResult();
    }

    public abstract Task<VerificationResult> VerifyAsync(T value);
}