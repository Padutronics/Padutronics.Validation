using Padutronics.Extensions.System.Collections.Generic;
using Padutronics.Validation.Verifiers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        return count >= expectedLowerBound ? OperationResults.Success : OperationResults.Failure;
    }
}