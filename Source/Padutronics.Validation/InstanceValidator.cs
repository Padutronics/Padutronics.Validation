using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padutronics.Validation;

public sealed class InstanceValidator<T> : IValidator
{
    private readonly T instance;
    private readonly IValidator<T> validator;

    public InstanceValidator(T instance, IValidator<T> validator)
    {
        this.instance = instance;
        this.validator = validator;
    }

    public ValidationResult Result { get; private set; } = ValidationResults.Success;

    public event EventHandler<ValidationResultChangedEventArgs>? ResultChanged;

    private bool AreErrorsEqual(ValidationResult oldResult, ValidationResult newResult, string propertyName)
    {
        var areEqual = false;

        if (oldResult.TryGetError(propertyName, out ValidationError? oldError))
        {
            if (newResult.TryGetError(propertyName, out ValidationError? newError))
            {
                areEqual = Enumerable.SequenceEqual(oldError.Messages, newError.Messages);
            }
        }
        else
        {
            areEqual = !newResult.ContainsError(propertyName);
        }

        return areEqual;
    }

    private void OnResultChanged(ValidationResultChangedEventArgs e)
    {
        ResultChanged?.Invoke(this, e);
    }

    private ValidationResult UpdateResultAndNotify(ValidationResult currentResult)
    {
        IEnumerable<string> removedPropertyNames = Result.PropertyNames.Except(currentResult.PropertyNames);
        IEnumerable<string> addedPropertyNames = currentResult.PropertyNames.Except(Result.PropertyNames);
        IEnumerable<string> commonPropertyNames = Result.PropertyNames
            .Intersect(currentResult.PropertyNames)
            .Where(propertyName => !AreErrorsEqual(Result, currentResult, propertyName));

        IEnumerable<string> propertyNames = removedPropertyNames
            .Concat(commonPropertyNames)
            .Concat(addedPropertyNames);

        Result = currentResult;

        foreach (string propertyName in propertyNames)
        {
            OnResultChanged(new ValidationResultChangedEventArgs(propertyName, Result));
        }

        return currentResult;
    }

    private ValidationResult UpdateResultAndNotify(ValidationResult currentResult, string propertyName)
    {
        if (!AreErrorsEqual(Result, currentResult, propertyName))
        {
            IEnumerable<ValidationError> errors = Result
                .GetErrors()
                .Where(error => error.PropertyName != propertyName)
                .Concat(currentResult.GetErrors())
                .ToList();

            Result = new ValidationResult(errors);

            OnResultChanged(new ValidationResultChangedEventArgs(propertyName, Result));
        }

        return Result;
    }

    public ValidationResult Validate()
    {
        return UpdateResultAndNotify(validator.Validate(instance));
    }

    public ValidationResult Validate(CascadeMode cascadeMode)
    {
        return UpdateResultAndNotify(validator.Validate(instance, cascadeMode));
    }

    public ValidationResult Validate(string propertyName)
    {
        return UpdateResultAndNotify(validator.Validate(instance, propertyName), propertyName);
    }

    public ValidationResult Validate(string propertyName, CascadeMode cascadeMode)
    {
        return UpdateResultAndNotify(validator.Validate(instance, propertyName, cascadeMode), propertyName);
    }

    public async Task<ValidationResult> ValidateAsync()
    {
        return UpdateResultAndNotify(await validator.ValidateAsync(instance));
    }

    public async Task<ValidationResult> ValidateAsync(CascadeMode cascadeMode)
    {
        return UpdateResultAndNotify(await validator.ValidateAsync(instance, cascadeMode));
    }

    public async Task<ValidationResult> ValidateAsync(string propertyName)
    {
        return UpdateResultAndNotify(await validator.ValidateAsync(instance, propertyName), propertyName);
    }

    public async Task<ValidationResult> ValidateAsync(string propertyName, CascadeMode cascadeMode)
    {
        return UpdateResultAndNotify(await validator.ValidateAsync(instance, propertyName, cascadeMode), propertyName);
    }
}