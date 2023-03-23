using NUnit.Framework;
using Padutronics.Validation.Rules.Building;
using Padutronics.Validation.Test.Stubs.Models;
using Padutronics.Validation.Test.Stubs.Verifiers;
using System.Collections.Generic;

namespace Padutronics.Validation.Test.Opertators;

[TestFixture]
internal sealed class Operator_any
{
    private sealed class ModelValidator : Validator<Model<IEnumerable<int>>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<IEnumerable<int>>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Has.Any.VerifiableBy(new EqualToVerifier<int>(3))
                .WithMessage("All values are not equal to 3.");
        }
    }

    [Test]
    public void Validation_is_failed_if_all_values_are_invalid()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<IEnumerable<int>>(new[] { 2, 2 });

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }

    [Test]
    public void Validation_is_succeeded_if_at_least_one_value_is_valid_and_one_is_invalid()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<IEnumerable<int>>(new[] { 2, 3 });

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_succeeded_if_all_values_are_valid()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<IEnumerable<int>>(new[] { 3, 3 });

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }
}