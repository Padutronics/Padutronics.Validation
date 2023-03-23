namespace Padutronics.Validation.Rules.Building.Fluent;

public interface INegatableVerificationStage<out TRuleChainBuilder, out TTarget, out TValue> : IVerificationStage<TRuleChainBuilder, TTarget, TValue>
{
    IVerificationStage<TRuleChainBuilder, TTarget, TValue> Not { get; }
}