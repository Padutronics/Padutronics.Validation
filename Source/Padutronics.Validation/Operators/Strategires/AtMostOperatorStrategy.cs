using Padutronics.Extensions.System.Collections.Generic;
using Padutronics.Validation.Verifiers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        int count = value.Count(item => verificationData.Verifier.Verify(target, item).IsSucceeded ^ verificationData.IsVerificationNegated);

        return EvaluateCount(count);
    }

    public async Task<OperationResult> EvaluateAsync(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        int count = await value.CountAsync(async item => (await verificationData.Verifier.VerifyAsync(target, item)).IsSucceeded ^ verificationData.IsVerificationNegated);

        return EvaluateCount(count);
    }

    private OperationResult EvaluateCount(int count)
    {
        return count <= expectedUpperBound ? OperationResults.Success : OperationResults.Failure;
    }
}