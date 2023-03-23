namespace Padutronics.Validation.Policies;

internal interface IValidationPolicy
{
    bool ShouldValidate(string propertyName);
}