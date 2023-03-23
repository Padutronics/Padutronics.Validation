using Padutronics.Validation.Verifiers;
using System.Collections.Generic;
using System.Linq;

namespace Padutronics.Validation.Operators.Strategires;

internal sealed class AllOperatorStrategy<TTarget, TValue> : IOperatorStrategy<TTarget, TValue, IEnumerable<TValue>>
{
    public OperationResult Evaluate(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        return value.All(item => verificationData.Verifier.Verify(target, item).IsSucceeded ^ verificationData.IsVerificationNegated)
            ? OperationResults.Success
            : OperationResults.Failure;
    }
}