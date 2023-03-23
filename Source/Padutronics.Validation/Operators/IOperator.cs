using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Operators;

internal interface IOperator<TTarget, TValue>
{
    OperationResult Evaluate(TTarget target, VerificationData<TTarget, TValue> verificationData);
}