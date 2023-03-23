using Padutronics.Extensions.System.Collections.Generic;
using Padutronics.Validation.Verifiers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padutronics.Validation.Operators.Strategires;

internal sealed class NoneOperatorStrategy<TTarget, TValue> : IOperatorStrategy<TTarget, TValue, IEnumerable<TValue>>
{
    public OperationResult Evaluate(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        return value.Any(item => verificationData.Verifier.Verify(target, item).IsSucceeded ^ verificationData.IsVerificationNegated)
            ? OperationResults.Failure
            : OperationResults.Success;
    }

    public async Task<OperationResult> EvaluateAsync(TTarget target, IEnumerable<TValue> value, VerificationData<TTarget, TValue> verificationData)
    {
        return await value.AnyAsync(async item => (await verificationData.Verifier.VerifyAsync(target, item)).IsSucceeded ^ verificationData.IsVerificationNegated)
            ? OperationResults.Failure
            : OperationResults.Success;
    }
}