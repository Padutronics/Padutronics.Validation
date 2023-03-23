namespace Padutronics.Validation.Fluent.Language;

public interface ISome<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Some { get; }
}