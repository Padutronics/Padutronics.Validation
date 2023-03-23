using Padutronics.Validation.Fluent;
using Padutronics.Validation.Operators;
using Padutronics.Validation.Operators.Strategires;
using Padutronics.Validation.ValueExtractors;
using System.Collections.Generic;

namespace Padutronics.Validation.Rules.Building;

internal sealed class SequencePropertyRuleBuilder<TRuleChainBuilder, TTarget, TValue> : RuleBuilder<TRuleChainBuilder, TTarget, TValue>, INegatableOperatorStage<TRuleChainBuilder, TTarget, TValue>
{
    private readonly IValueExtractor<TTarget, IEnumerable<TValue>> valueExtractor;

    public SequencePropertyRuleBuilder(TRuleChainBuilder ruleChainBuilder, IValueExtractor<TTarget, IEnumerable<TValue>> valueExtractor) :
        base(ruleChainBuilder)
    {
        this.valueExtractor = valueExtractor;
    }

    public INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> All => SetOperatorStrategy(new AllOperatorStrategy<TTarget, TValue>());

    public IOperatorStage<TRuleChainBuilder, TTarget, TValue> No
    {
        get
        {
            NegateOperator();

            return this;
        }
    }

    private SequencePropertyRuleBuilder<TRuleChainBuilder, TTarget, TValue> SetOperatorStrategy(IOperatorStrategy<TTarget, TValue, IEnumerable<TValue>> operatorStrategy)
    {
        SetOperator(new Operator<TTarget, TValue, IEnumerable<TValue>>(operatorStrategy, valueExtractor));

        return this;
    }
}