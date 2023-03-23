using System;
using System.Threading.Tasks;

namespace Padutronics.Validation.Verifiers;

public sealed class AsyncDelegateVerifier<T> : AsyncVerifier<T>
{
    private readonly Func<T, Task<VerificationResult>> verifyMethod;

    public AsyncDelegateVerifier(Func<T, Task<VerificationResult>> verifyMethod)
    {
        this.verifyMethod = verifyMethod;
    }

    public override Task<VerificationResult> VerifyAsync(T value)
    {
        return verifyMethod(value);
    }
}