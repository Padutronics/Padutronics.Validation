using Padutronics.Validation.Operators;
using Padutronics.Validation.Operators.Strategires;
using Padutronics.Validation.ValueExtractors;

namespace Padutronics.Validation.Rules.Building;

internal sealed class ValuePropertyRuleBuilder<TRuleChainBuilder, TTarget, TValue> : RuleBuilder<TRuleChainBuilder, TTarget, TValue>
{
    public ValuePropertyRuleBuilder(TRuleChainBuilder ruleChainBuilder, IValueExtractor<TTarget, TValue> valueExtractor) :
        base(ruleChainBuilder)
    {
        SetOperator(new Operator<TTarget, TValue, TValue>(new IsOperatorStrategy<TTarget, TValue>(), valueExtractor));
    }
}