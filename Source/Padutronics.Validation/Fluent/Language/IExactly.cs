using Padutronics.Validation.Operators.Strategires;

namespace Padutronics.Validation.Fluent.Language;

public interface IExactly<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Exactly(ExpectedCount expectedCount);
}