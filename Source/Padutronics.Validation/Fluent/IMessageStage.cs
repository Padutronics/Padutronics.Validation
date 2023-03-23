using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Fluent;

public interface IMessageStage<out TRuleChainBuilder, out TTarget> : IWithMessage<TRuleChainBuilder, TTarget>
{
}