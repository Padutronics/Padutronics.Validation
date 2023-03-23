namespace Padutronics.Validation.Messages;

public interface IMessageProvider<in T>
{
    string GetMessage(T instance);
}