﻿using Padutronics.Validation.Policies;
using Padutronics.Validation.Rules;
using Padutronics.Validation.Rules.Building;
using System;
using System.Threading.Tasks;

namespace Padutronics.Validation;

public abstract class Validator<T> : IValidator<T>
{
    private const CascadeMode DefaultCascadeMode = CascadeMode.Continue;

    private readonly Lazy<RuleSet<T>> ruleSet;

    protected Validator()
    {
        ruleSet = new Lazy<RuleSet<T>>(CreateRuleSet);
    }

    protected abstract void BuildRuleSet(IRuleSetBuilder<T> ruleSetBuilder);

    private RuleSet<T> CreateRuleSet()
    {
        var ruleSetBuilder = new RuleSetBuilder<T>();

        BuildRuleSet(ruleSetBuilder);

        return ruleSetBuilder.Build();
    }

    public ValidationResult Validate(T instance)
    {
        return Validate(instance, DefaultCascadeMode);
    }

    public ValidationResult Validate(T instance, CascadeMode cascadeMode)
    {
        return ValidateCore(instance, new AnyPropertyValidationPolicy(), cascadeMode);
    }

    public ValidationResult Validate(T instance, string propertyName)
    {
        return Validate(instance, propertyName, DefaultCascadeMode);
    }

    public ValidationResult Validate(T instance, string propertyName, CascadeMode cascadeMode)
    {
        return ValidateCore(instance, new NamedPropertyValidationPolicy(propertyName), cascadeMode);
    }

    public Task<ValidationResult> ValidateAsync(T instance)
    {
        return ValidateAsync(instance, DefaultCascadeMode);
    }

    public Task<ValidationResult> ValidateAsync(T instance, CascadeMode cascadeMode)
    {
        return ValidateCoreAsync(instance, new AnyPropertyValidationPolicy(), cascadeMode);
    }

    public Task<ValidationResult> ValidateAsync(T instance, string propertyName)
    {
        return ValidateAsync(instance, propertyName, DefaultCascadeMode);
    }

    public Task<ValidationResult> ValidateAsync(T instance, string propertyName, CascadeMode cascadeMode)
    {
        return ValidateCoreAsync(instance, new NamedPropertyValidationPolicy(propertyName), cascadeMode);
    }

    private ValidationResult ValidateCore(T instance, IValidationPolicy validationPolicy, CascadeMode cascadeMode)
    {
        return ruleSet.Value.Validate(new ValidationContext<T>(instance, validationPolicy, cascadeMode));
    }

    private Task<ValidationResult> ValidateCoreAsync(T instance, IValidationPolicy validationPolicy, CascadeMode cascadeMode)
    {
        return ruleSet.Value.ValidateAsync(new ValidationContext<T>(instance, validationPolicy, cascadeMode));
    }
}