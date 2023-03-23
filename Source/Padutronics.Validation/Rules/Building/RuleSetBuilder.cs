using Padutronics.Validation.ValueExtractors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Padutronics.Validation.Rules.Building;

internal sealed class RuleSetBuilder<TTarget> : IRuleSetBuilder<TTarget>
{
    private readonly IDictionary<string, ICollection<IRuleChainBuilder<TTarget>>> propertyNameToRuleChainBuildersMappings = new Dictionary<string, ICollection<IRuleChainBuilder<TTarget>>>();

    private TRuleChainBuilder AddRuleChainBuilder<TRuleChainBuilder, TProperty>(Expression<Func<TTarget, TProperty>> propertyExpression, TRuleChainBuilder ruleChainBuilder)
        where TRuleChainBuilder : IRuleChainBuilder<TTarget>
    {
        string propertyName = GetPropertyName(propertyExpression);

        if (!propertyNameToRuleChainBuildersMappings.TryGetValue(propertyName, out ICollection<IRuleChainBuilder<TTarget>>? ruleChainBuilders))
        {
            ruleChainBuilders = new List<IRuleChainBuilder<TTarget>>();

            propertyNameToRuleChainBuildersMappings.Add(propertyName, ruleChainBuilders);
        }

        ruleChainBuilders.Add(ruleChainBuilder);

        return ruleChainBuilder;
    }

    public RuleSet<TTarget> Build()
    {
        IEnumerable<Profile<TTarget>> profiles = propertyNameToRuleChainBuildersMappings
            .Select(
                propertyNameToRuleChainBuildersMapping => new Profile<TTarget>(
                    propertyNameToRuleChainBuildersMapping.Key,
                    propertyNameToRuleChainBuildersMapping.Value
                        .Select(ruleChainBuilder => ruleChainBuilder.Build())
                        .ToList()
                )
            )
            .ToList();

        return new RuleSet<TTarget>(profiles);
    }

    private string GetPropertyName<TProperty>(Expression<Func<TTarget, TProperty>> propertyExpression)
    {
        if (propertyExpression.Body is MemberExpression memberExpression)
        {
            if (memberExpression.Member is PropertyInfo)
            {
                return memberExpression.Member.Name;
            }
        }

        throw new ArgumentException($"Expression {propertyExpression} is not a property expression.");
    }

    public IValuePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, TValue>> propertyExpression)
    {
        return AddRuleChainBuilder(propertyExpression, new ValuePropertyRuleChainBuilder<TTarget, TValue>(new PropertyValueExtractor<TTarget, TValue>(propertyExpression)));
    }

    public ISequencePropertyRuleChainBuilder<TTarget, TValue> Property<TValue>(Expression<Func<TTarget, TValue[]>> propertyExpression)
    {
        return AddRuleChainBuilder(propertyExpression, new SequencePropertyRuleChainBuilder<TTarget, TValue>(new PropertyValueExtractor<TTarget, TValue[]>(propertyExpression)));
    }
}