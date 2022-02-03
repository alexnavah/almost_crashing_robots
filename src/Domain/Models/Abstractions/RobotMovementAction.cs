using Domain.Models.Extensions;

namespace Domain.Models.Interfaces
{
    public abstract class RobotMovementAction
    {
        public abstract void Execute(Grid grid, Robot robot);

        public void HandleNextTileStatus(TileStatusType tileStatus, Grid grid, Robot robot, Coordinates nextCoordinates)
        {
            switch (tileStatus)
            {
                case TileStatusType.Ignore:
                    break;
                case TileStatusType.Lost:
                    HandleLostState(grid, robot, nextCoordinates);
                    break;
                case TileStatusType.Move:
                    HandleMoveState(grid, robot, nextCoordinates);
                    break;
            }
        }

        private void HandleLostState(Grid grid, Robot robot, Coordinates nextCoordinates)
        {
            robot.FlagAsLost();
            grid.AddLostRobotVector(DirectionVector.Create(robot.Coordinates, robot.Orientation));
        }
        private void HandleMoveState(Grid grid, Robot robot, Coordinates nextCoordinates)
        {
            grid.AddSafetile(nextCoordinates);
            robot.MoveToCoordinates(nextCoordinates);
        }
    }
}
