using Domain.Models.Interfaces;
using Domain.Models.Rules;
using System.Collections.Generic;

namespace Domain.Helpers
{
    public static class RuleHelper
    {
        public static IEnumerable<IValidation> GetValidationRules()
        {
            return new List<IValidation>
            {
                MapSizeValidation.Instance,
                MaxRobotInstructionsValidation.Instance,
                RobotInstructionValidation.Instance
            };
        }
    }
}
