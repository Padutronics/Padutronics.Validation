namespace Padutronics.Validation.Rules.Building.Fluent;

public interface INegatableOperatorStage<out TRuleChainBuilder, out TTarget, out TValue> : IOperatorStage<TRuleChainBuilder, TTarget, TValue>
{
    IOperatorStage<TRuleChainBuilder, TTarget, TValue> No { get; }
}