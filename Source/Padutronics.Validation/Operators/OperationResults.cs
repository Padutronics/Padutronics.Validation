namespace Padutronics.Validation.Operators;

internal static class OperationResults
{
    public static OperationResult Failure { get; } = new OperationResult(isSucceeded: false);

    public static OperationResult Success { get; } = new OperationResult(isSucceeded: true);
}