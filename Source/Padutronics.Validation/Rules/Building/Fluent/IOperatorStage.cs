using Padutronics.Validation.Operators.Strategires;

namespace Padutronics.Validation.Rules.Building.Fluent;

public interface IOperatorStage<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> All { get; }
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Any { get; }
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> None { get; }
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Some { get; }

    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> AtLeast(ExpectedCount expectedLowerBound);
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> AtMost(ExpectedCount expectedUpperBound);
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Exactly(ExpectedCount expectedCount);
}