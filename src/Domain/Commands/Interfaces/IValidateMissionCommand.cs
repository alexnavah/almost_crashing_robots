using Domain.Models;

namespace Domain.Commands.Interfaces
{
    public interface IValidateMissionCommand
    {
        public CommandResult Execute(Mission mission);
    }
}
