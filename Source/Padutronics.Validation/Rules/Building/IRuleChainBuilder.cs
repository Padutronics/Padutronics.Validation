namespace Padutronics.Validation.Rules.Building;

internal interface IRuleChainBuilder<TTarget>
{
    RuleChain<TTarget> Build();
}