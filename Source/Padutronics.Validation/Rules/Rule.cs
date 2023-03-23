using Padutronics.Validation.Messages;
using Padutronics.Validation.Operators;
using Padutronics.Validation.Verifiers;
using System.Diagnostics.CodeAnalysis;

namespace Padutronics.Validation.Rules;

internal sealed class Rule<TTarget, TValue> : IRule<TTarget>
{
    private readonly IMessageProvider<TTarget> messageProvider;
    private readonly OperationData<TTarget, TValue> operationData;
    private readonly VerificationData<TTarget, TValue> verificationData;

    public Rule(OperationData<TTarget, TValue> operationData, VerificationData<TTarget, TValue> verificationData, IMessageProvider<TTarget> messageProvider)
    {
        this.messageProvider = messageProvider;
        this.operationData = operationData;
        this.verificationData = verificationData;
    }

    private ValidationMessage CreateMessage(TTarget target)
    {
        string message = messageProvider.GetMessage(target);

        return new ValidationMessage(message);
    }

    private bool IsValid(TTarget target)
    {
        return operationData.Operator.Evaluate(target, verificationData).IsSucceeded ^ operationData.IsOperationNegated;
    }

    public bool TryEvaluate(TTarget target, [NotNullWhen(true)] out ValidationMessage? message)
    {
        message = null;

        if (verificationData.VerificationCondition(target))
        {
            if (!IsValid(target))
            {
                message = CreateMessage(target);
            }
        }

        return message is not null;
    }
}