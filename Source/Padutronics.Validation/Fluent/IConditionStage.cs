using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Fluent;

public interface IConditionStage<out TRuleChainBuilder, out TTarget> : IMessageStage<TRuleChainBuilder, TTarget>, IUnless<TRuleChainBuilder, TTarget>, IWhen<TRuleChainBuilder, TTarget>
{
}