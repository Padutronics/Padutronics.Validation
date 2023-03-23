using Padutronics.Validation.Verifiers;
using System.Threading.Tasks;

namespace Padutronics.Validation.Operators.Strategires;

internal interface IOperatorStrategy<TTarget, TVerificationValue, in TExtractionValue>
{
    OperationResult Evaluate(TTarget target, TExtractionValue value, VerificationData<TTarget, TVerificationValue> verificationData);
    Task<OperationResult> EvaluateAsync(TTarget target, TExtractionValue value, VerificationData<TTarget, TVerificationValue> verificationData);
}