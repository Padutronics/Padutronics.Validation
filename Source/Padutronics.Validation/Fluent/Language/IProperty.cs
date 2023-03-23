using Padutronics.Validation.Rules.Building;
using System;
using System.Linq.Expressions;

namespace Padutronics.Validation.Fluent.Language;

public interface IProperty<TTarget>
{
    IValuePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, TValue>> propertyExpression);
    ISequencePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, TValue[]>> propertyExpression);
}