using Domain.Models.Interfaces;
using Domain.Models.Rules;
using System.Collections.Generic;

namespace Domain.Helpers
{
    public static class ValidationHelper
    {
        public static IEnumerable<IValidation> GetValidations()
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
