using System;

namespace Padutronics.Validation.Fluent.Language;

public interface IWhen<out TRuleChainBuilder, out TTarget>
{
    IMessageStage<TRuleChainBuilder> When(Predicate<TTarget> condition);
}