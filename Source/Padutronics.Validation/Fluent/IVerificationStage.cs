using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Fluent;

public interface IVerificationStage<out TRuleChainBuilder, out TTarget, out TValue> : IVerifiableBy<TRuleChainBuilder, TTarget, TValue>
{
}