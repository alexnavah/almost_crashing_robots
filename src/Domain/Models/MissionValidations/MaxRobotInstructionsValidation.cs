using Domain.Models.Interfaces;

namespace Domain.Models.Rules
{
    public class MaxRobotInstructionsValidation : IValidation
    {
        const int MaxRobotInstructions = 100;

        private static MaxRobotInstructionsValidation Current { get; set; }

        private MaxRobotInstructionsValidation()
        {

        }

        public static MaxRobotInstructionsValidation Instance => Current ??= new MaxRobotInstructionsValidation();

        public void Run(Mission mission, ValidationResult validationResult)
        {
            foreach (var robot in mission.Robots)
            {
                if (robot.Commands.Length > MaxRobotInstructions)
                {
                    validationResult.AddMessage($"Maximum length of robot instructions is {MaxRobotInstructions}");
                }
            }
        }
    }
}
