namespace Padutronics.Validation.Policies;

internal sealed class AnyPropertyValidationPolicy : IValidationPolicy
{
    public bool ShouldValidate(string propertyName)
    {
        return true;
    }
}