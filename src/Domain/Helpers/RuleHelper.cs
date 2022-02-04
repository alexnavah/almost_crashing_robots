using Domain.Models.Interfaces;
using Domain.Models.Rules;
using System.Collections.Generic;

namespace Domain.Helpers
{
    public static class RuleHelper
    {
        public static IEnumerable<IValidationRule> GetValidationRules()
        {
            return new List<IValidationRule>
            {
                MapSizeRule.Instance,
                MaxRobotInstructionsRule.Instance,
                RobotInstructionRule.Instance
            };
        }
    }
}
