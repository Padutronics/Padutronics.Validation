using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Rules.Building;

public interface IValuePropertyRuleChainBuilder<out TTarget, out TValue> : IIs<IValuePropertyRuleChainBuilder<TTarget, TValue>, TTarget, TValue>
{
}