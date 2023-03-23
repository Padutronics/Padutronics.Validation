using Padutronics.Validation.Verifiers;
using System.Threading.Tasks;

namespace Padutronics.Validation.Operators;

internal interface IOperator<TTarget, TValue>
{
    OperationResult Evaluate(TTarget target, VerificationData<TTarget, TValue> verificationData);
    Task<OperationResult> EvaluateAsync(TTarget target, VerificationData<TTarget, TValue> verificationData);
}