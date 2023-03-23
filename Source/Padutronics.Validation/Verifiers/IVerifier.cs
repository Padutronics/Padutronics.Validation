namespace Padutronics.Validation.Verifiers;

public interface IVerifier<in T>
{
    VerificationResult Verify(T value);
}