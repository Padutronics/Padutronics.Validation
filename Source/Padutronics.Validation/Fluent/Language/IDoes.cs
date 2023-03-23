namespace Padutronics.Validation.Fluent.Language;

public interface IDoes<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Does { get; }
}