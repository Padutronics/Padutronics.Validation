using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Rules.Building.Fluent;

public interface IVerificationStage<out TRuleChainBuilder, out TTarget, out TValue>
{
    IConditionStage<TRuleChainBuilder, TTarget> VerifiableBy(IVerifier<TValue> verifier);
    IConditionStage<TRuleChainBuilder, TTarget> VerifiableBy(IVerifier<TTarget, TValue> verifier);
}