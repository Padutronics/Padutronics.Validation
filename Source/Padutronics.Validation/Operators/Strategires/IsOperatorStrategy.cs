using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Operators.Strategires;

internal sealed class IsOperatorStrategy<TTarget, TValue> : IOperatorStrategy<TTarget, TValue, TValue>
{
    public OperationResult Evaluate(TTarget target, TValue value, VerificationData<TTarget, TValue> verificationData)
    {
        return verificationData.Verifier.Verify(target, value).IsSucceeded ^ verificationData.IsVerificationNegated
            ? OperationResults.Success
            : OperationResults.Failure;
    }
}