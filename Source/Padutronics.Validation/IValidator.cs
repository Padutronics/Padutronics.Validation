using System;

namespace Padutronics.Validation;

public interface IValidator
{
    ValidationResult Result { get; }

    event EventHandler<ValidationResultChangedEventArgs>? ResultChanged;

    ValidationResult Validate();
    ValidationResult Validate(CascadeMode cascadeMode);
    ValidationResult Validate(string propertyName);
    ValidationResult Validate(string propertyName, CascadeMode cascadeMode);
}