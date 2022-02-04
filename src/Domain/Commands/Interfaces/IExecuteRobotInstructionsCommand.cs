using Domain.Models;

namespace Domain.Commands.Interfaces
{
    public interface IExecuteRobotInstructionsCommand
    {
        public CommandResult Execute(Robot robot, Map map);
    }
}
