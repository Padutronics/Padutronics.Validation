using Padutronics.Validation.Operators.Strategires;
using Padutronics.Validation.ValueExtractors;
using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Operators;

internal sealed class Operator<TTarget, TVerificationValue, TExtractionValue> : IOperator<TTarget, TVerificationValue>
{
    private readonly IOperatorStrategy<TTarget, TVerificationValue, TExtractionValue> strategy;
    private readonly IValueExtractor<TTarget, TExtractionValue> valueExtractor;

    public Operator(IOperatorStrategy<TTarget, TVerificationValue, TExtractionValue> strategy, IValueExtractor<TTarget, TExtractionValue> valueExtractor)
    {
        this.strategy = strategy;
        this.valueExtractor = valueExtractor;
    }

    public OperationResult Evaluate(TTarget target, VerificationData<TTarget, TVerificationValue> verificationData)
    {
        TExtractionValue value = valueExtractor.Extract(target);

        return strategy.Evaluate(target, value, verificationData);
    }
}