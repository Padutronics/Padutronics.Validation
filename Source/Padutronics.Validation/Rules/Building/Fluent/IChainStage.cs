namespace Padutronics.Validation.Rules.Building.Fluent;

public interface IChainStage<out TRuleChainBuilder>
{
    TRuleChainBuilder And { get; }
}