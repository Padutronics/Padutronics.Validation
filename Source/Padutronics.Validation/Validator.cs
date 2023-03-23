using Padutronics.Validation.Policies;
using Padutronics.Validation.Rules;
using Padutronics.Validation.Rules.Building;
using System;

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
        return Validate(instance, new AnyPropertyValidationPolicy(), cascadeMode);
    }

    public ValidationResult Validate(T instance, string propertyName)
    {
        return Validate(instance, propertyName, DefaultCascadeMode);
    }

    public ValidationResult Validate(T instance, string propertyName, CascadeMode cascadeMode)
    {
        return Validate(instance, new NamedPropertyValidationPolicy(propertyName), cascadeMode);
    }

    private ValidationResult Validate(T instance, IValidationPolicy validationPolicy, CascadeMode cascadeMode)
    {
        return ruleSet.Value.Validate(new ValidationContext<T>(instance, validationPolicy, cascadeMode));
    }
}