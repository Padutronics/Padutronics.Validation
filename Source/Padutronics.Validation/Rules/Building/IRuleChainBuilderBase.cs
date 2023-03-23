using Padutronics.Validation.Fluent;

namespace Padutronics.Validation.Rules.Building;

public interface IRuleChainBuilderBase<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Does { get; }
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Is { get; }
}