namespace Padutronics.Validation.Messages;

public delegate string MessageFactory<in T>(T instance);