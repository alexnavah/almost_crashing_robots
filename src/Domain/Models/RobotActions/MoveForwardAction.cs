using Domain.Models.Extensions;
using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class MoveForwardAction : IRobotMovementAction
    {
        private static MoveForwardAction Current { get; set; }

        private MoveForwardAction() { }

        public static MoveForwardAction Instance => Current ??= new MoveForwardAction();

        public void Execute(Grid grid, Robot robot)
        {
            var nextCoordinates = robot.GetForwardCoordinates();
            var tileStatus = grid.CheckTileStatus(nextCoordinates);

            switch (tileStatus)
            {
                case TileStatusType.Ignore:
                    break;
                case TileStatusType.Lost:
                    robot.FlagAsLost();
                    grid.AddLostRobotTile(nextCoordinates);
                    break;
                case TileStatusType.Move:
                    grid.AddSafetile(nextCoordinates);
                    robot.MoveToCoordinates(nextCoordinates);
                    break;
            }
        }
    }
}