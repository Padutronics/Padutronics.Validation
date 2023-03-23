namespace Padutronics.Validation.Fluent.Language;

public interface IWithMessage<out TRuleChainBuilder>
{
    IChainStage<TRuleChainBuilder> WithMessage(string message);
}