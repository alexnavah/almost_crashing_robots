using Domain.Models;

namespace Domain.Commands.Interfaces
{
    public interface IValidateMissionRulesCommand
    {
        public CommandResult Execute(Mission map);
    }
}
