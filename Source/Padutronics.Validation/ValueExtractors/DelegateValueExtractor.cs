using System;

namespace Padutronics.Validation.ValueExtractors;

public sealed class DelegateValueExtractor<TTarget, TValue> : IValueExtractor<TTarget, TValue>
{
    private readonly Func<TTarget, TValue> extractionMethod;

    public DelegateValueExtractor(Func<TTarget, TValue> extractionMethod)
    {
        this.extractionMethod = extractionMethod;
    }

    public TValue Extract(TTarget target)
    {
        return extractionMethod(target);
    }
}