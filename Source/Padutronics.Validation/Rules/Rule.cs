using Padutronics.Validation.Messages;
using Padutronics.Validation.Operators;
using Padutronics.Validation.Verifiers;
using System.Threading.Tasks;

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

    public ValidationMessage? Evaluate(TTarget target)
    {
        return EvaluateCoreAsync(target, isAsync: false).GetAwaiter().GetResult();
    }

    public Task<ValidationMessage?> EvaluateAsync(TTarget target)
    {
        return EvaluateCoreAsync(target, isAsync: true);
    }

    private async Task<ValidationMessage?> EvaluateCoreAsync(TTarget target, bool isAsync)
    {
        ValidationMessage? message = null;

        if (verificationData.VerificationCondition(target))
        {
            OperationResult operationResult = isAsync
                ? await operationData.Operator.EvaluateAsync(target, verificationData)
                : operationData.Operator.Evaluate(target, verificationData);

            bool isValid = operationResult.IsSucceeded ^ operationData.IsOperationNegated;
            if (!isValid)
            {
                message = CreateMessage(target);
            }
        }

        return message;
    }
}