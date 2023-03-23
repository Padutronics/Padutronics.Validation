using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Fluent;

public interface INegatableVerificationStage<out TRuleChainBuilder, out TTarget, out TValue> : IVerificationStage<TRuleChainBuilder, TTarget, TValue>, INot<TRuleChainBuilder, TTarget, TValue>
{
}