using Padutronics.Extensions.System.Collections.Generic;
using Padutronics.Validation.Verifiers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padutronics.Validation.Operators.Strategires;

internal sealed class AllOperatorStrategy<TTarget, TValue> : IOperatorStrategy<TTarget, TValue, IEnumerable<TValue>>
{
    public OperationResult Evaluate(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        return value.All(item => verificationData.Verifier.Verify(target, item).IsSucceeded ^ verificationData.IsVerificationNegated)
            ? OperationResults.Success
            : OperationResults.Failure;
    }

    public async Task<OperationResult> EvaluateAsync(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        return await value.AllAsync(async item => (await verificationData.Verifier.VerifyAsync(target, item)).IsSucceeded ^ verificationData.IsVerificationNegated)
            ? OperationResults.Success
            : OperationResults.Failure;
    }
}