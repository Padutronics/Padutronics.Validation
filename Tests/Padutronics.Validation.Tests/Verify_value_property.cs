using NUnit.Framework;
using Padutronics.Validation.Rules.Building;
using Padutronics.Validation.Test.Models;
using Padutronics.Validation.Test.Verifiers;

namespace Padutronics.Validation.Test;

[TestFixture]
internal sealed class Verify_value_property
{
    private sealed class ModelValidator : Validator<Model<int>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<int>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.VerifiableBy(new EqualToVerifier<int>(3))
                .WithMessage("Value is not equal to 3.");
        }
    }

    [Test]
    public void Validation_is_failed()
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
    public void Validation_is_succeeded()
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