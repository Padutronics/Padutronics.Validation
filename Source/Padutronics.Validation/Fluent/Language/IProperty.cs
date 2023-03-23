using Padutronics.Validation.Rules.Building;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Padutronics.Validation.Fluent.Language;

public interface IProperty<TTarget>
{
    IValuePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, TValue>> propertyExpression);
    ISequencePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, TValue[]>> propertyExpression);
    ISequencePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, ICollection<TValue>>> propertyExpression);
    ISequencePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, IEnumerable<TValue>>> propertyExpression);
    ISequencePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, IList<TValue>>> propertyExpression);
    ISequencePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, IReadOnlyCollection<TValue>>> propertyExpression);
    ISequencePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, IReadOnlyList<TValue>>> propertyExpression);
}