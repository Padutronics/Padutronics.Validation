namespace Padutronics.Validation.Fluent.Language;

public interface IIs<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Is { get; }
}