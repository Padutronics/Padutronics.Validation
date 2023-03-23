namespace Padutronics.Validation;

public interface IValidator<in T>
{
    ValidationResult Validate(T instance);
    ValidationResult Validate(T instance, CascadeMode cascadeMode);
    ValidationResult Validate(T instance, string propertyName);
    ValidationResult Validate(T instance, string propertyName, CascadeMode cascadeMode);
}