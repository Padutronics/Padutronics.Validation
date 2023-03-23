namespace Padutronics.Validation.Messages;

internal sealed class FactoryMessageProvider<T> : IMessageProvider<T>
{
    private readonly MessageFactory<T> messageFactory;

    public FactoryMessageProvider(MessageFactory<T> messageFactory)
    {
        this.messageFactory = messageFactory;
    }

    public string GetMessage(T instance)
    {
        return messageFactory(instance);
    }
}