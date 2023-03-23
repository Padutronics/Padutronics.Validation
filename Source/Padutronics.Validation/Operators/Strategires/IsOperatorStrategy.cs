using Padutronics.Validation.Verifiers;
using System.Threading.Tasks;

namespace Padutronics.Validation.Operators.Strategires;

internal sealed class IsOperatorStrategy<TTarget, TValue> : IOperatorStrategy<TTarget, TValue, TValue>
{
    public OperationResult Evaluate(TTarget target, TValue value, VerificationData<TTarget, TValue> verificationData)
    {
        return verificationData.Verifier.Verify(target, value).IsSucceeded ^ verificationData.IsVerificationNegated
            ? OperationResults.Success
            : OperationResults.Failure;
    }

    public async Task<OperationResult> EvaluateAsync(TTarget target, TValue value, VerificationData<TTarget, TValue> verificationData)
    {
        return (await verificationData.Verifier.VerifyAsync(target, value)).IsSucceeded ^ verificationData.IsVerificationNegated
            ? OperationResults.Success
            : OperationResults.Failure;
    }
}