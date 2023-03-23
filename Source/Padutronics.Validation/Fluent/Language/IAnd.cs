namespace Padutronics.Validation.Fluent.Language;

public interface IAnd<out TRuleChainBuilder>
{
    TRuleChainBuilder And { get; }
}