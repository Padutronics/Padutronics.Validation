using System;

namespace Padutronics.Validation.Fluent.Language;

public interface IUnless<out TRuleChainBuilder, out TTarget>
{
    IMessageStage<TRuleChainBuilder, TTarget> Unless(Predicate<TTarget> condition);
}