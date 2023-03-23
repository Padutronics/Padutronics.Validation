using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Fluent;

public interface IMessageStage<out TRuleChainBuilder> : IWithMessage<TRuleChainBuilder>
{
}