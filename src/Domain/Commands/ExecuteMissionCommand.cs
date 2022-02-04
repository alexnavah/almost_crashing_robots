using Domain.Commands.Interfaces;
using Domain.Models;
using Domain.Models.Extensions;

namespace Domain.Commands
{
    /// <inheritdoc cref="IExecuteMissionCommand"/>
    public class ExecuteMissionCommand : IExecuteMissionCommand
    {
        /// <inheritdoc cref="IExecuteMissionCommand.Execute(Mission)"/>
        public CommandResultOfT<Mission> Execute(Mission mission)
        {
            var commandResult = CommandResultOfT<Mission>.Create();

            foreach(var robot in mission.Robots)
            {
                var commands = robot.GetCommands();

                while(!robot.IsLost && commands.TryDequeue(out var command))
                {
                    command.Execute(mission, robot);
                }
            }

            commandResult.SetResult(mission);

            return commandResult;
        }
    }
}
