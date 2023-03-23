using Padutronics.Validation.Rules.Building.Fluent;
using System.Collections.Generic;

namespace Padutronics.Validation.Rules.Building;

public interface ISequencePropertyRuleChainBuilder<out TTarget, out TValue> : IRuleChainBuilderBase<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, IEnumerable<TValue>>
{
    INegatableOperatorStage<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue> Has { get; }
}