using Domain.Models.Extensions;

namespace Domain.Models.Abstractions
{
    public abstract class RobotMovementAction
    {
        public abstract void Execute(Map map, Robot robot);

        public void HandleNextTileStatus(TileStatusType tileStatus, Map map, Robot robot, Coordinates nextCoordinates)
        {
            switch (tileStatus)
            {
                case TileStatusType.Ignore:
                    break;
                case TileStatusType.Lost:
                    HandleLostState(map, robot);
                    break;
                case TileStatusType.Move:
                    HandleMoveState(map, robot, nextCoordinates);
                    break;
            }
        }

        private void HandleLostState(Map map, Robot robot)
        {
            robot.FlagAsLost();
            map.AddLostRobotVector(DirectionVector.Create(robot.Coordinates, robot.Orientation));
        }
        private void HandleMoveState(Map map, Robot robot, Coordinates nextCoordinates)
        {
            map.AddSafetile(nextCoordinates);
            robot.MoveToCoordinates(nextCoordinates);
        }
    }
}
