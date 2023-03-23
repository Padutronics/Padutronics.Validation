namespace Padutronics.Validation.Fluent;

public interface IChainStage<out TRuleChainBuilder>
{
    TRuleChainBuilder And { get; }
}