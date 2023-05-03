using System;
namespace permissions_n5_challenge.Domain.Commons.Rules
{
	public abstract class Rule
	{
        protected static void ValidateRule(IRule rule)
        {
            if (!rule.IsValid())
            {
                throw new InvalidRuleException(rule);
            }
        }
    }
}

