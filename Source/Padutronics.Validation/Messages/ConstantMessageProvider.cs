namespace Padutronics.Validation.Messages;

internal sealed class ConstantMessageProvider<T> : IMessageProvider<T>
{
    private readonly string message;

    public ConstantMessageProvider(string message)
    {
        this.message = message;
    }

    public string GetMessage(T instance)
    {
        return message;
    }
}