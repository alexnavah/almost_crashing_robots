using Domain.Models.Extensions;
using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class MoveForwardInstruction : IRobotInstruction
    {
        private static MoveForwardInstruction Current { get; set; }

        private MoveForwardInstruction() { }

        public static MoveForwardInstruction Instance => Current ??= new MoveForwardInstruction();

        public void Execute(Mission mission, Robot robot)
        {
            var nextCoordinates = robot.GetForwardCoordinates();
            var tileStatus = mission.Map.CheckTileStatus(nextCoordinates, robot.Orientation);

            mission.HandleNextTileStatus(tileStatus, robot, nextCoordinates);
        }
    }
}