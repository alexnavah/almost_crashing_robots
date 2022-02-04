using Domain.Models.Interfaces;

namespace Domain.Models.Rules
{
    public class MaxRobotInstructionsRule : IValidationRule
    {
        const int MaxRobotInstructions = 100;

        private static MaxRobotInstructionsRule Current { get; set; }

        private MaxRobotInstructionsRule()
        {

        }

        public static MaxRobotInstructionsRule Instance => Current ??= new MaxRobotInstructionsRule();

        public void Run(Mission map, ValidationResult validationResult)
        {
            foreach (var robot in map.Robots)
            {
                if (robot.Commands.Length > MaxRobotInstructions)
                {
                    validationResult.AddMessage($"Maximum length of robot instructions is {MaxRobotInstructions}");
                }
            }
        }
    }
}
