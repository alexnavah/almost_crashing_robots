using Domain.Commands.Interfaces;
using Domain.Models;

namespace Domain.Commands
{
    public class ExecuteRobotInstructionsCommand : IExecuteRobotInstructionsCommand
    {
        public CommandResult Execute(Robot robot, Map map)
        {
            throw new System.NotImplementedException();
        }
    }
}
