using Padutronics.Validation.Rules.Building.Fluent;
using Padutronics.Validation.ValueExtractors;

namespace Padutronics.Validation.Rules.Building;

internal class ValuePropertyRuleChainBuilder<TTarget, TValue> : RuleChainBuilder<TTarget>, IValuePropertyRuleChainBuilder<TTarget, TValue>
{
    private readonly IValueExtractor<TTarget, TValue> valueExtractor;

    public ValuePropertyRuleChainBuilder(IValueExtractor<TTarget, TValue> valueExtractor)
    {
        this.valueExtractor = valueExtractor;
    }

    public INegatableVerificationStage<IValuePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue> Does => Is;

    public INegatableVerificationStage<IValuePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue> Is => AddRuleBuilder(new ValuePropertyRuleBuilder<IValuePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue>(ruleChainBuilder: this, valueExtractor));
}