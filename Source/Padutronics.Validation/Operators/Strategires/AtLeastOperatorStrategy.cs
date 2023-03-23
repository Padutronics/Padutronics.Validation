using Padutronics.Validation.Verifiers;
using System.Collections.Generic;
using System.Linq;

namespace Padutronics.Validation.Operators.Strategires;

internal sealed class AtLeastOperatorStrategy<TTarget, TValue> : IOperatorStrategy<TTarget, TValue, IEnumerable<TValue>>
{
    private readonly ExpectedCount expectedLowerBound;

    public AtLeastOperatorStrategy(ExpectedCount expectedLowerBound)
    {
        this.expectedLowerBound = expectedLowerBound;
    }

    public OperationResult Evaluate(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        return value.Count(item => verificationData.Verifier.Verify(target, item).IsSucceeded ^ verificationData.IsVerificationNegated) >= expectedLowerBound
            ? OperationResults.Success
            : OperationResults.Failure;
    }
}