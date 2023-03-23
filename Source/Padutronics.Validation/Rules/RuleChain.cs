using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Padutronics.Validation.Rules;

internal sealed class RuleChain<TTarget>
{
    private readonly IEnumerable<IRule<TTarget>> rules;

    public RuleChain(IEnumerable<IRule<TTarget>> rules)
    {
        this.rules = rules;
    }

    public bool TryEvaluate(TTarget target, [NotNullWhen(true)] out ValidationMessage? message)
    {
        message = null;

        foreach (IRule<TTarget> rule in rules)
        {
            if (rule.TryEvaluate(target, out message))
            {
                break;
            }
        }

        return message is not null;
    }
}