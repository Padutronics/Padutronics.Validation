using System;

namespace Padutronics.Validation.Fluent.Language;

public interface IUnless<out TRuleChainBuilder, out TTarget>
{
    IMessageStage<TRuleChainBuilder> Unless(Predicate<TTarget> condition);
}