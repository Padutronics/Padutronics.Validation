using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

public interface IVerifier<in TTarget, in TValue>
{
    VerificationResult Verify(TTarget target, TValue value);
    Task<VerificationResult> VerifyAsync(TTarget target, TValue value);
}