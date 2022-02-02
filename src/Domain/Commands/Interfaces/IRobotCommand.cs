using Domain.Models;

namespace Domain.Commands.Interfaces
{
    public interface IRobotCommand
    {
        public CommandResult Execute(Robot robot, Grid grid);
    }
}
