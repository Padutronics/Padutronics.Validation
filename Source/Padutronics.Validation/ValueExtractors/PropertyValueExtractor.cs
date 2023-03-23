using System;
using System.Linq.Expressions;

namespace Padutronics.Validation.ValueExtractors;

internal sealed class PropertyValueExtractor<TTarget, TValue> : IValueExtractor<TTarget, TValue>
{
    private readonly Lazy<Func<TTarget, TValue>> compiledPropertyExpression;

    public PropertyValueExtractor(Expression<Func<TTarget, TValue>> propertyExpression)
    {
        compiledPropertyExpression = new Lazy<Func<TTarget, TValue>>(propertyExpression.Compile);
    }

    public TValue Extract(TTarget target)
    {
        return compiledPropertyExpression.Value.Invoke(target);
    }
}