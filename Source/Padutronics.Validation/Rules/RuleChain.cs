using System.Collections.Generic;
using System.Threading.Tasks;

namespace Padutronics.Validation.Rules;

internal sealed class RuleChain<TTarget>
{
    private readonly IEnumerable<IRule<TTarget>> rules;

    public RuleChain(IEnumerable<IRule<TTarget>> rules)
    {
        this.rules = rules;
    }

    public ValidationMessage? Evaluate(TTarget target)
    {
        return EvaluateAsync(target, isAsync: false).GetAwaiter().GetResult();
    }

    public Task<ValidationMessage?> EvaluateAsync(TTarget target)
    {
        return EvaluateAsync(target, isAsync: true);
    }

    private async Task<ValidationMessage?> EvaluateAsync(TTarget target, bool isAsync)
    {
        ValidationMessage? message = null;

        foreach (IRule<TTarget> rule in rules)
        {
            message = isAsync
                ? await rule.EvaluateAsync(target)
                : rule.Evaluate(target);
            if (message is not null)
            {
                break;
            }
        }

        return message;
    }
}