using NUnit.Framework;
using Padutronics.Validation.Rules.Building;
using Padutronics.Validation.Test.Stubs.Models;
using Padutronics.Validation.Test.Stubs.Verifiers;

namespace Padutronics.Validation.Test.Opertators;

[TestFixture]
internal sealed class Operator_is
{
    private sealed class ModelValidator : Validator<Model<int>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<int>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.VerifiableBy(new EqualToVerifier<int>(3))
                .WithMessage("Not all values are equal to 3.");
        }
    }

    [Test]
    public void Validation_is_failed_if_value_is_invalid()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(2);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_valid()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(3);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }
}