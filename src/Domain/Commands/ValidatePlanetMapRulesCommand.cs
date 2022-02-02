using Domain.Commands.Interfaces;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Commands
{
    public class ValidatePlanetMapRulesCommand : IValidatePlanetMapRulesCommandCommand
    {
        public ValidatePlanetMapRulesCommand()
        {

        }

        public CommandResult Execute(PlanetMap map)
        {
            var commandResult = CommandResult.Create();
            var validationResult = ValidationResult.Create();
            var rules = RuleHelper.GetValidationRules();

            foreach (var rule in rules)
            {
                rule.Run(map, validationResult);
            }

            commandResult.AddMessages(validationResult.Messages);

            return commandResult;
        }
    }
}
