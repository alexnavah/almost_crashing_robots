using Domain.Commands.Interfaces;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Commands
{
    /// <inheritdoc cref="IValidateMissionCommand"/>
    public class ValidateMissionCommand : IValidateMissionCommand
    {
        /// <inheritdoc cref="IValidateMissionCommand.Execute(Mission)"/>
        public CommandResult Execute(Mission mission)
        {
            var commandResult = CommandResult.Create();
            var validationResult = ValidationResult.Create();
            var rules = ValidationHelper.GetValidations();

            foreach (var rule in rules)
            {
                rule.Run(mission, validationResult);
            }

            commandResult.AddMessages(validationResult.Messages);

            return commandResult;
        }
    }
}
