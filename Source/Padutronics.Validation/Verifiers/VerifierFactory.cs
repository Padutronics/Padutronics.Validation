namespace Padutronics.Validation.Verifiers;

public delegate IVerifier<TValue> VerifierFactory<TTarget, TValue>(TTarget target);