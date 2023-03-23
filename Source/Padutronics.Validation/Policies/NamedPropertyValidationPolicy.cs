namespace Padutronics.Validation.Policies;

internal sealed class NamedPropertyValidationPolicy : IValidationPolicy
{
    private readonly string propertyName;

    public NamedPropertyValidationPolicy(string propertyName)
    {
        this.propertyName = propertyName;
    }

    public bool ShouldValidate(string propertyName)
    {
        return this.propertyName == propertyName;
    }
}