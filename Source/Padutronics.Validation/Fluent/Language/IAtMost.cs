using Padutronics.Validation.Operators.Strategires;

namespace Padutronics.Validation.Fluent.Language;

public interface IAtMost<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> AtMost(ExpectedCount expectedUpperBound);
}