namespace Padutronics.Validation.Fluent.Language;

public interface IHas<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableOperatorStage<TRuleChainBuilder, TTarget, TValue> Has { get; }
}