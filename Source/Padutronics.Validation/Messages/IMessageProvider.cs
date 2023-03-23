namespace Padutronics.Validation.Messages;

internal interface IMessageProvider<in T>
{
    string GetMessage(T instance);
}