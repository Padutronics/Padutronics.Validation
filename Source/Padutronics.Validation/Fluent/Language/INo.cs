namespace Padutronics.Validation.Fluent.Language;

public interface INo<out TRuleChainBuilder, out TTarget, out TValue>
{
    IOperatorStage<TRuleChainBuilder, TTarget, TValue> No { get; }
}