using Padutronics.Validation.Verifiers;
using System.Collections.Generic;
using System.Linq;

namespace Padutronics.Validation.Operators.Strategires;

internal sealed class NoneOperatorStrategy<TTarget, TValue> : IOperatorStrategy<TTarget, TValue, IEnumerable<TValue>>
{
    public OperationResult Evaluate(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        return value.Any(item => verificationData.Verifier.Verify(target, item).IsSucceeded ^ verificationData.IsVerificationNegated)
            ? OperationResults.Failure
            : OperationResults.Success;
    }
}