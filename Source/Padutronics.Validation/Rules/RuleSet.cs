﻿using System.Collections.Generic;
using System.Linq;

namespace Padutronics.Validation.Rules;

internal sealed class RuleSet<TTarget>
{
    private readonly IEnumerable<Profile<TTarget>> profiles;

    public RuleSet(IEnumerable<Profile<TTarget>> profiles)
    {
        this.profiles = profiles;
    }

    public ValidationResult Validate(ValidationContext<TTarget> context)
    {
        var propertyNameToMessagesMappings = new Dictionary<string, ICollection<ValidationMessage>>();
        var shouldContinue = true;

        foreach (Profile<TTarget> profile in profiles)
        {
            if (context.ValidationPolicy.ShouldValidate(profile.PropertyName))
            {
                foreach (RuleChain<TTarget> ruleChain in profile.RuleChains)
                {
                    if (ruleChain.TryEvaluate(context.Target, out ValidationMessage? message))
                    {
                        if (!propertyNameToMessagesMappings.TryGetValue(profile.PropertyName, out ICollection<ValidationMessage>? messages))
                        {
                            messages = new List<ValidationMessage>();

                            propertyNameToMessagesMappings.Add(profile.PropertyName, messages);
                        }

                        messages.Add(message);

                        if (context.CascadeMode == CascadeMode.StopOnFirstError)
                        {
                            shouldContinue = false;
                            break;
                        }
                    }
                }

                if (!shouldContinue)
                {
                    break;
                }
            }
        }

        IEnumerable<ValidationError> errors = propertyNameToMessagesMappings
            .Select(
                propertyNameToMessagesMapping => new ValidationError(
                    propertyName: propertyNameToMessagesMapping.Key,
                    messages: propertyNameToMessagesMapping.Value
                )
            )
            .ToList();

        return new ValidationResult(errors);
    }
}