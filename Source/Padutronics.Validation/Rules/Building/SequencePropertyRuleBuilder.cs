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

    public INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Any => SetOperatorStrategy(new AnyOperatorStrategy<TTarget, TValue>());

    public IOperatorStage<TRuleChainBuilder, TTarget, TValue> No
    {
        get
        {
            NegateOperator();

            return this;
        }
    }

    public INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> None => SetOperatorStrategy(new NoneOperatorStrategy<TTarget, TValue>());

    public INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> AtLeast(ExpectedCount expectedLowerBound)
    {
        return SetOperatorStrategy(new AtLeastOperatorStrategy<TTarget, TValue>(expectedLowerBound));
    }

    public INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Exactly(ExpectedCount expectedCount)
    {
        return SetOperatorStrategy(new ExactCountOperatorStrategy<TTarget, TValue>(expectedCount));
    }

    private SequencePropertyRuleBuilder<TRuleChainBuilder, TTarget, TValue> SetOperatorStrategy(IOperatorStrategy<TTarget, TValue, IEnumerable<TValue>> operatorStrategy)
    {
        SetOperator(new Operator<TTarget, TValue, IEnumerable<TValue>>(operatorStrategy, valueExtractor));

        return this;
    }
}