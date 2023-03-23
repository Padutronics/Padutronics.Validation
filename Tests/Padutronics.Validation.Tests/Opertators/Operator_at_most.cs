using NUnit.Framework;
using Padutronics.Validation.Rules.Building;
using Padutronics.Validation.Test.Stubs.Models;
using Padutronics.Validation.Test.Stubs.Verifiers;
using System.Collections.Generic;

namespace Padutronics.Validation.Test.Opertators;

[TestFixture]
internal sealed class Operator_at_most
{
    private sealed class ModelValidator : Validator<Model<IEnumerable<int>>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<IEnumerable<int>>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Has.AtMost(2).VerifiableBy(new EqualToVerifier<int>(3))
                .WithMessage("More than 2 values are equal to 3.");
        }
    }

    [Test]
    public void Validation_is_succeeded_if_all_values_are_invalid()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<IEnumerable<int>>(new[] { 2, 2, 2 });

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_succeeded_if_there_are_less_valid_values_than_specified()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<IEnumerable<int>>(new[] { 2, 2, 3 });

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_succeeded_if_amount_of_valid_values_is_exactly_as_specified()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<IEnumerable<int>>(new[] { 2, 3, 3 });

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_there_are_more_valid_values_than_specified()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<IEnumerable<int>>(new[] { 3, 3, 3 });

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}