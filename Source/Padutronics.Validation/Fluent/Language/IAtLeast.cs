using Padutronics.Validation.Operators.Strategires;

namespace Padutronics.Validation.Fluent.Language;

public interface IAtLeast<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> AtLeast(ExpectedCount expectedLowerBound);
}