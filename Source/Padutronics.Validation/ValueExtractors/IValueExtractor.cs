namespace Padutronics.Validation.ValueExtractors;

public interface IValueExtractor<in TTarget, out TValue>
{
    TValue Extract(TTarget target);
}