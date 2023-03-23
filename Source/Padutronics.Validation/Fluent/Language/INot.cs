namespace Padutronics.Validation.Fluent.Language;

public interface INot<out TRuleChainBuilder, out TTarget, out TValue>
{
    IVerificationStage<TRuleChainBuilder, TTarget, TValue> Not { get; }
}