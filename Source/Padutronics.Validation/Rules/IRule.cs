using System.Threading.Tasks;

namespace Padutronics.Validation.Rules;

internal interface IRule<in TTarget>
{
    ValidationMessage? Evaluate(TTarget target);
    Task<ValidationMessage?> EvaluateAsync(TTarget target);
}