namespace Padutronics.Validation.Fluent.Language;

public interface INone<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> None { get; }
}