namespace Padutronics.Validation.Operators;

internal sealed class OperationData<TTarget, TValue>
{
    public OperationData(IOperator<TTarget, TValue> @operator, bool isOperationNegated)
    {
        IsOperationNegated = isOperationNegated;
        Operator = @operator;
    }

    public bool IsOperationNegated { get; }

    public IOperator<TTarget, TValue> Operator { get; }
}