using Domain.Models.Abstractions;
using Domain.Models.Extensions;

namespace Domain.Models
{
    public class MoveForwardAction : RobotMovementAction
    {
        private static MoveForwardAction Current { get; set; }

        private MoveForwardAction() { }

        public static MoveForwardAction Instance => Current ??= new MoveForwardAction();

        public override void Execute(Map map, Robot robot)
        {
            var nextCoordinates = robot.GetForwardCoordinates();
            var tileStatus = map.CheckTileStatus(nextCoordinates);

            HandleNextTileStatus(tileStatus, map, robot, nextCoordinates);
        }
    }
}