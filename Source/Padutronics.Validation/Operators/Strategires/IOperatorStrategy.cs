using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Operators.Strategires;

internal interface IOperatorStrategy<TTarget, TVerificationValue, in TExtractionValue>
{
    OperationResult Evaluate(TTarget target, TExtractionValue value, VerificationData<TTarget, TVerificationValue> verificationData);
}