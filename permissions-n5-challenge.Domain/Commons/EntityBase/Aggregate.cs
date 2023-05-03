using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using permissions_n5_challenge.Domain.Commons.Rules;

namespace permissions_n5_challenge.Domain.Commons.EntityBase
{
    public abstract class Aggregate
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
