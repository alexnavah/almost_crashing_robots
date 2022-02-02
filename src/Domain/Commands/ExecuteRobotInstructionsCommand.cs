using Domain.Commands.Interfaces;
using Domain.Models;

namespace Domain.Commands
{
    public class ExecuteRobotInstructionsCommand : IExecuteRobotInstructionsCommand
    {
        public CommandResult Execute(Robot robot, Grid grid)
        {
            throw new System.NotImplementedException();
        }
    }
}
