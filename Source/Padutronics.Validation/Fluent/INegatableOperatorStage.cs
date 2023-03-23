using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Fluent;

public interface INegatableOperatorStage<out TRuleChainBuilder, out TTarget, out TValue> : IOperatorStage<TRuleChainBuilder, TTarget, TValue>, INo<TRuleChainBuilder, TTarget, TValue>
{
}