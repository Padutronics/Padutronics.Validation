namespace Padutronics.Validation.ValueExtractors;

internal interface IValueExtractor<in TTarget, out TValue>
{
    TValue Extract(TTarget target);
}