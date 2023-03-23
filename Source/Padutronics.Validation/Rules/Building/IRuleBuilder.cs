namespace Padutronics.Validation.Rules.Building;

internal interface IRuleBuilder<TTarget>
{
    IRule<TTarget> Build();
}