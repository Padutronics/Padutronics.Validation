using System.Collections.Generic;

namespace Padutronics.Validation.Rules;

internal sealed class Profile<TTarget>
{
    public Profile(string propertyName, IEnumerable<RuleChain<TTarget>> ruleChains)
    {
        PropertyName = propertyName;
        RuleChains = ruleChains;
    }

    public string PropertyName { get; }

    public IEnumerable<RuleChain<TTarget>> RuleChains { get; }
}