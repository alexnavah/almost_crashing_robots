using Domain.Models.Extensions;
using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class MoveForwardAction : RobotMovementAction
    {
        private static MoveForwardAction Current { get; set; }

        private MoveForwardAction() { }

        public static MoveForwardAction Instance => Current ??= new MoveForwardAction();

        public override void Execute(Grid grid, Robot robot)
        {
            var nextCoordinates = robot.GetForwardCoordinates();
            var tileStatus = grid.CheckTileStatus(nextCoordinates);

            HandleNextTileStatus(tileStatus, grid, robot, nextCoordinates);
        }
    }
}