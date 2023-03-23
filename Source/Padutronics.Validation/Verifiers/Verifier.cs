using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

public abstract class Verifier<T> : IVerifier<T>
{
    public abstract VerificationResult Verify(T value);

    public Task<VerificationResult> VerifyAsync(T value)
    {
        return Task.FromResult(Verify(value));
    }
}