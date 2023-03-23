namespace Padutronics.Validation.Verifiers;

public static class VerificationResults
{
    public static VerificationResult Failure { get; } = new VerificationResult(isSucceeded: false);

    public static VerificationResult Success { get; } = new VerificationResult(isSucceeded: true);
}