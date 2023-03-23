using System.Collections.Generic;
using System.Linq;

namespace Padutronics.Validation.Rules.Building;

internal abstract class RuleChainBuilder<TTarget> : IRuleChainBuilder<TTarget>
{
    private readonly ICollection<IRuleBuilder<TTarget>> ruleBuilders = new List<IRuleBuilder<TTarget>>();

    protected TRuleBuilder AddRuleBuilder<TRuleBuilder>(TRuleBuilder ruleBuilder)
        where TRuleBuilder : IRuleBuilder<TTarget>
    {
        ruleBuilders.Add(ruleBuilder);

        return ruleBuilder;
    }

    public RuleChain<TTarget> Build()
    {
        return new RuleChain<TTarget>(
            ruleBuilders
                .Select(ruleBuilder => ruleBuilder.Build())
                .ToList()
        );
    }
}