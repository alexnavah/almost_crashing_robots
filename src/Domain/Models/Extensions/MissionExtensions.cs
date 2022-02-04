using System.Text;

namespace Domain.Models.Extensions
{
    public static class MissionExtensions
    {
        public static void HandleNextTileStatus(this Mission mission, TileStatusType tileStatus, Robot robot, Coordinates nextCoordinates)
        {
            switch (tileStatus)
            {
                case TileStatusType.Ignore:
                    break;
                case TileStatusType.Lost:
                    HandleLostState(mission.Map, robot);
                    break;
                case TileStatusType.Move:
                    HandleMoveState(mission.Map, robot, nextCoordinates);
                    break;
            }
        }

        public static string GetWrittenMissionReport(this Mission mission)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Sample output");
            foreach (var robot in mission.Robots)
            {
                stringBuilder.AppendLine($"{robot.Coordinates.X} {robot.Coordinates.Y} {robot.Orientation.GetKeyCode()} {robot.GetLostStatus()}");
            }

            return stringBuilder.ToString();
        }
        private static void HandleLostState(Map map, Robot robot)
        {
            robot.FlagAsLost();
            map.AddLostRobotVector(DirectionVector.Create(robot.Coordinates, robot.Orientation));
        }
        private static void HandleMoveState(Map map, Robot robot, Coordinates nextCoordinates)
        {
            map.AddSafetile(nextCoordinates);
            robot.MoveToCoordinates(nextCoordinates);
        }
    }
}
