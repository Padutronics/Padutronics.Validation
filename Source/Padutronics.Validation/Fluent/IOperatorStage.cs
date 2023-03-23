using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Fluent;

public interface IOperatorStage<out TRuleChainBuilder, out TTarget, out TValue> : IAll<TRuleChainBuilder, TTarget, TValue>, IAny<TRuleChainBuilder, TTarget, TValue>, IExactly<TRuleChainBuilder, TTarget, TValue>, INone<TRuleChainBuilder, TTarget, TValue>
{
}