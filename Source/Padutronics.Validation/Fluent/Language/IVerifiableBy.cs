using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Fluent.Language;

public interface IVerifiableBy<out TRuleChainBuilder, out TTarget, out TValue>
{
    IConditionStage<TRuleChainBuilder, TTarget> VerifiableBy(ITargetVerifier<TTarget, TValue> verifier);
    IConditionStage<TRuleChainBuilder, TTarget> VerifiableBy(IVerifier<TValue> verifier);
}