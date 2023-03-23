using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Fluent;

public interface IVerificationStage<out TRuleChainBuilder, out TTarget, out TValue>
{
    IConditionStage<TRuleChainBuilder, TTarget> VerifiableBy(IVerifier<TValue> verifier);
    IConditionStage<TRuleChainBuilder, TTarget> VerifiableBy(IVerifier<TTarget, TValue> verifier);
}