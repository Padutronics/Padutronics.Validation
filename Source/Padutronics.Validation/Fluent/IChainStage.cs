using Padutronics.Validation.Fluent.Language;

namespace Padutronics.Validation.Fluent;

public interface IChainStage<out TRuleChainBuilder> : IAnd<TRuleChainBuilder>
{
}