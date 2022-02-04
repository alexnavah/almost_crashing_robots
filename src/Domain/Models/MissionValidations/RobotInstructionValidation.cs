using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.Rules
{
    public class RobotInstructionValidation : IValidation
    {
        private static RobotInstructionValidation Current { get; set; }

        private RobotInstructionValidation()
        {

        }

        public static RobotInstructionValidation Instance => Current ??= new RobotInstructionValidation();

        public void Run(Mission mission, ValidationResult validationResult)
        {
            var validCommands = new HashSet<char>(Enum.GetValues(typeof(RobotCommandType)).Cast<RobotCommandType>().Select(t => (char)t));

            for (int i = 0; i < mission.Robots.Count; i++)
            {
                var instructions = mission.Robots.ElementAt(i).Commands;

                foreach(var instruction in instructions)
                {
                    if (!validCommands.Contains(instruction))
                    {
                        validationResult.AddMessage($"Invalid command <{instruction}> found in robot {i} input. ");
                    }
                }
            }
        }
    }
}
