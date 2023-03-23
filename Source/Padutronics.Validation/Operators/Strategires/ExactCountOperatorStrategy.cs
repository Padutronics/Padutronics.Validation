using Padutronics.Validation.Verifiers;
using System.Collections.Generic;
using System.Linq;

namespace Padutronics.Validation.Operators.Strategires;

internal sealed class ExactCountOperatorStrategy<TTarget, TValue> : IOperatorStrategy<TTarget, TValue, IEnumerable<TValue>>
{
    private readonly ExpectedCount expectedCount;

    public ExactCountOperatorStrategy(ExpectedCount expectedCount)
    {
        this.expectedCount = expectedCount;
    }

    public OperationResult Evaluate(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        return value.Count(item => verificationData.Verifier.Verify(target, item).IsSucceeded ^ verificationData.IsVerificationNegated) == expectedCount
            ? OperationResults.Success
            : OperationResults.Failure;
    }
}