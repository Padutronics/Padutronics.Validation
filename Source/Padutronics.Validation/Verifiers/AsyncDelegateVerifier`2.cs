using System;
using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

public sealed class AsyncDelegateVerifier<TTarget, TValue> : AsyncVerifier<TTarget, TValue>
{
    private readonly Func<TTarget, TValue, Task<VerificationResult>> verifyMethod;

    public AsyncDelegateVerifier(Func<TTarget, TValue, Task<VerificationResult>> verifyMethod)
    {
        this.verifyMethod = verifyMethod;
    }

    public override Task<VerificationResult> VerifyAsync(TTarget target, TValue value)
    {
        return verifyMethod(target, value);
    }
}