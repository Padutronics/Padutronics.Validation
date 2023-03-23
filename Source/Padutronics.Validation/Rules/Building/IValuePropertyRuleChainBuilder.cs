using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Rules.Building;

public interface IValuePropertyRuleChainBuilder<out TTarget, out TValue> : IDoes<IValuePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue>, IIs<IValuePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue>
{
}