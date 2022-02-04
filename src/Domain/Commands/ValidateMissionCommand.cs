using Domain.Commands.Interfaces;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Commands
{
    public class ValidateMissionCommand : IValidateMissionCommand
    {
        public ValidateMissionCommand()
        {

        }

        public CommandResult Execute(Mission mission)
        {
            var commandResult = CommandResult.Create();
            var validationResult = ValidationResult.Create();
            var rules = RuleHelper.GetValidationRules();

            foreach (var rule in rules)
            {
                rule.Run(mission, validationResult);
            }

            commandResult.AddMessages(validationResult.Messages);

            return commandResult;
        }
    }
}
