﻿namespace Padutronics.Validation.Fluent.Language;

public interface IAny<out TRuleChainBuilder, out TTarget, out TValue>
{
    INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue> Any { get; }
}