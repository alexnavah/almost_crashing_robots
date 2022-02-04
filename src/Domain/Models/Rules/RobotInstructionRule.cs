using Domain.Models.Interfaces;
using System.Linq;

namespace Domain.Models.Rules
{
    public class RobotInstructionRule : IValidationRule
    {
        private static RobotInstructionRule Current { get; set; }

        private RobotInstructionRule()
        {

        }

        public static RobotInstructionRule Instance => Current ??= new RobotInstructionRule();

        public void Run(Mission map, ValidationResult validationResult)
        {
            for (int i = 0; i < map.Robots.Count; i++)
            {
                var instructions = map.Robots.ElementAt(i).Commands;

                foreach(var instruction in instructions)
                {

                }
            }
        }
    }
}
