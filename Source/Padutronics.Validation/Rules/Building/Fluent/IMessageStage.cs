using Padutronics.Validation.Messages;

namespace Padutronics.Validation.Rules.Building.Fluent;

public interface IMessageStage<out TRuleChainBuilder, out TTarget>
{
    IChainStage<TRuleChainBuilder> WithMessage(string message);
    IChainStage<TRuleChainBuilder> WithMessage(IMessageProvider<TTarget> messageProvider);
    IChainStage<TRuleChainBuilder> WithMessage(MessageFactory<TTarget> messageFactory);
}