using Padutronics.Validation.Fluent.Language;
using System.Collections.Generic;

namespace Padutronics.Validation.Rules.Building;

public interface ISequencePropertyRuleChainBuilder<out TTarget, out TValue> : IDoes<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, IEnumerable<TValue>>, IHas<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue>, IIs<ISequencePropertyRuleChainBuilder<TTarget, TValue>, TTarget, IEnumerable<TValue>>
{
}