using Padutronics.Validation.Verifiers;
using System.Collections.Generic;
using System.Linq;

namespace Padutronics.Validation.Operators.Strategires;

internal sealed class AtMostOperatorStrategy<TTarget, TValue> : IOperatorStrategy<TTarget, TValue, IEnumerable<TValue>>
{
    private readonly ExpectedCount expectedUpperBound;

    public AtMostOperatorStrategy(ExpectedCount expectedUpperBound)
    {
        this.expectedUpperBound = expectedUpperBound;
    }

    public OperationResult Evaluate(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        return value.Count(item => verificationData.Verifier.Verify(target, item).IsSucceeded ^ verificationData.IsVerificationNegated) <= expectedUpperBound
            ? OperationResults.Success
            : OperationResults.Failure;
    }
}