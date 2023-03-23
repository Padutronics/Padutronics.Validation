using System.Diagnostics.CodeAnalysis;

namespace Padutronics.Validation.Rules;

internal interface IRule<in TTarget>
{
    bool TryEvaluate(TTarget target, [NotNullWhen(true)] out ValidationMessage? message);
}