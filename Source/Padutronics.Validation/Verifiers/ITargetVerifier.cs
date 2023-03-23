using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

// TODO: Replace with IVerifier<,>.
public interface ITargetVerifier<in TTarget, in TValue>
{
    VerificationResult Verify(TTarget target, TValue value);
    Task<VerificationResult> VerifyAsync(TTarget target, TValue value);
}