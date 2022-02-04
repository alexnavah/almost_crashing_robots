using Domain.Models;

namespace Domain.Commands.Interfaces
{
    /// <summary>
    /// Validate mission parameters before launch
    /// </summary>
    public interface IValidateMissionCommand
    {
        /// <summary>
        /// Execute mission validations configured in ValidationHelper
        /// </summary>
        /// <param name="mission">The mission object to validate</param>
        /// <returns>The <see cref="CommandResult"/>. Result of the mission validation</returns>
        public CommandResult Execute(Mission mission);
    }
}
