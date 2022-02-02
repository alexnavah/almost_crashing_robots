using Domain.Models.Validations;
using System.Collections.Generic;

namespace Domain.Helpers
{
    public static class RuleHelper
    {
        public static IEnumerable<IValidationRule> GetValidationRules()
        {
            return new List<IValidationRule>
            {
                MaxGridSizeRule.Instance,
                MaxRobotInstructionsRule.Instance
            };
        }
    }
}
