using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

public interface IVerifier<in T>
{
    VerificationResult Verify(T value);
    Task<VerificationResult> VerifyAsync(T value);
}