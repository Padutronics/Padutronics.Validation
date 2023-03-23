using Padutronics.Validation.Rules.Building.Fluent;
using Padutronics.Validation.ValueExtractors;
using System.Collections.Generic;

namespace Padutronics.Validation.Rules.Building;

internal sealed class SequencePropertyRuleChainBuilder<TTarget, TValue> : RuleChainBuilder<TTarget>, ISequencePropertyRuleChainBuilder<TTarget, TValue>, IRuleChainBuilder<TTarget>
{
    private readonly IValueExtractor<TTarget, IEnumerable<TValue>> valueExtractor;

    public SequencePropertyRuleChainBuilder(IValueExtractor<TTarget, IEnumerable<TValue>> valueExtractor)
    {
        this.valueExtractor = valueExtractor;
    }

    public INegatableVerificationStage<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, IEnumerable<TValue>> Does => Is;

    public INegatableOperatorStage<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue> Has => AddRuleBuilder(new SequencePropertyRuleBuilder<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue>(ruleChainBuilder: this, valueExtractor));

    public INegatableVerificationStage<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, IEnumerable<TValue>> Is => AddRuleBuilder(new ValuePropertyRuleBuilder<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, IEnumerable<TValue>>(ruleChainBuilder: this, valueExtractor));
}