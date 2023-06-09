﻿using System;
using System.Threading.Tasks;

namespace Padutronics.Validation;

public interface IValidator
{
    ValidationResult Result { get; }

    event EventHandler<ValidationResultChangedEventArgs>? ResultChanged;

    ValidationResult Validate();
    ValidationResult Validate(CascadeMode cascadeMode);
    ValidationResult Validate(string propertyName);
    ValidationResult Validate(string propertyName, CascadeMode cascadeMode);
    Task<ValidationResult> ValidateAsync();
    Task<ValidationResult> ValidateAsync(CascadeMode cascadeMode);
    Task<ValidationResult> ValidateAsync(string propertyName);
    Task<ValidationResult> ValidateAsync(string propertyName, CascadeMode cascadeMode);
}