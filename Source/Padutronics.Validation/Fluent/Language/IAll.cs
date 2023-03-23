namespace Padutronics.Validation.Fluent.Language;

public interface IAll<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> All { get; }
}