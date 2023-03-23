using Padutronics.Validation.Policies;

namespace Padutronics.Validation;

internal sealed class ValidationContext<TTarget>
{
    public ValidationContext(TTarget target, IValidationPolicy validationPolicy, CascadeMode cascadeMode)
    {
        CascadeMode = cascadeMode;
        Target = target;
        ValidationPolicy = validationPolicy;
    }

    public CascadeMode CascadeMode { get; }

    public TTarget Target { get; }

    public IValidationPolicy ValidationPolicy { get; }
}