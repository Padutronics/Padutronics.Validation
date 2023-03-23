using System;

namespace Padutronics.Validation.Fluent.Language;

public interface IWhen<out TRuleChainBuilder, out TTarget>
{
    IMessageStage<TRuleChainBuilder, TTarget> When(Predicate<TTarget> condition);
}