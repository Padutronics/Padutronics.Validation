using System;

namespace Padutronics.Validation.Rules.Building.Fluent;

public interface IConditionStage<out TRuleChainBuilder, out TTarget> : IMessageStage<TRuleChainBuilder, TTarget>
{
    IMessageStage<TRuleChainBuilder, TTarget> Unless(Predicate<TTarget> condition);
    IMessageStage<TRuleChainBuilder, TTarget> When(Predicate<TTarget> condition);
}