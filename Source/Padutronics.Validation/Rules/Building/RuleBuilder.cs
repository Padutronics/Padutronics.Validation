using Padutronics.Validation.Fluent;
using Padutronics.Validation.Messages;
using Padutronics.Validation.Operators;
using Padutronics.Validation.Verifiers;
using Padutronics.Validation.Verifiers.Adapters;
using System;

namespace Padutronics.Validation.Rules.Building;

internal abstract class RuleBuilder<TRuleChainBuilder, TTarget, TValue> : IRuleBuilder<TTarget>, IChainStage<TRuleChainBuilder>, IConditionStage<TRuleChainBuilder, TTarget>, INegatableVerificationStage<TRuleChainBuilder, TTarget, TValue>
{
    private readonly TRuleChainBuilder ruleChainBuilder;

    private bool isOperationNegated;
    private bool isVerificationNegated;
    private IMessageProvider<TTarget>? messageProvider;
    private IOperator<TTarget, TValue>? @operator;
    private Predicate<TTarget> verificationCondition = _ => true;
    private ITargetVerifier<TTarget, TValue>? verifier;

    protected RuleBuilder(TRuleChainBuilder ruleChainBuilder)
    {
        this.ruleChainBuilder = ruleChainBuilder;
    }

    public TRuleChainBuilder And => ruleChainBuilder;

    public IVerificationStage<TRuleChainBuilder, TTarget, TValue> Not
    {
        get
        {
            isVerificationNegated = true;

            return this;
        }
    }

    public IRule<TTarget> Build()
    {
        if (messageProvider is null)
        {
            throw new InvalidOperationException("Message provider was not configured.");
        }
        if (@operator is null)
        {
            throw new InvalidOperationException("Operator was not configured.");
        }
        if (verifier is null)
        {
            throw new InvalidOperationException("Verifier was not configured.");
        }

        return new Rule<TTarget, TValue>(
            new OperationData<TTarget, TValue>(@operator, isOperationNegated),
            new VerificationData<TTarget, TValue>(verifier, verificationCondition, isVerificationNegated),
            messageProvider
        );
    }

    protected void NegateOperator()
    {
        isOperationNegated = false;
    }

    protected void SetOperator(IOperator<TTarget, TValue> @operator)
    {
        this.@operator = @operator;
    }

    public IMessageStage<TRuleChainBuilder, TTarget> Unless(Predicate<TTarget> condition)
    {
        return When(target => !condition(target));
    }

    public IConditionStage<TRuleChainBuilder, TTarget> VerifiableBy(ITargetVerifier<TTarget, TValue> verifier)
    {
        this.verifier = verifier;

        return this;
    }

    public IConditionStage<TRuleChainBuilder, TTarget> VerifiableBy(IVerifier<TValue> verifier)
    {
        return VerifiableBy(new VerifierToTargetVerifierAdapter<TTarget, TValue>(verifier));
    }

    public IMessageStage<TRuleChainBuilder, TTarget> When(Predicate<TTarget> condition)
    {
        verificationCondition = condition;

        return this;
    }

    public IChainStage<TRuleChainBuilder> WithMessage(string message)
    {
        return WithMessage(new ConstantMessageProvider<TTarget>(message));
    }

    public IChainStage<TRuleChainBuilder> WithMessage(IMessageProvider<TTarget> messageProvider)
    {
        this.messageProvider = messageProvider;

        return this;
    }

    public IChainStage<TRuleChainBuilder> WithMessage(MessageFactory<TTarget> messageFactory)
    {
        return WithMessage(new FactoryMessageProvider<TTarget>(messageFactory));
    }
}