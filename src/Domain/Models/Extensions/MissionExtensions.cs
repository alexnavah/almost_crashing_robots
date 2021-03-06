using System.Linq;
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

        public static string GetRawOutput(this Mission mission)
        {
            var stringBuilder = new StringBuilder();
            GetRobotsOutput(mission, stringBuilder);

            return stringBuilder.ToString();
        }

        public static string GetWrittenMissionReport(this Mission mission)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Sample output");
            GetRobotsOutput(mission, stringBuilder);

            return stringBuilder.ToString();
        }

        public static decimal GetSuccessPercentage(this Mission mission)
        {
            var robots = mission.Robots;
            var lostRobots = robots.Where(r => r.IsLost).Count();

            return lostRobots * 100 / robots.Count;
        }
        public static decimal GetExploredPercentage(this Mission mission)
        {
            return mission.Map.ExploredTiles.Count * 100 / mission.Map.GetNumberOfTiles();
        }

        private static StringBuilder GetRobotsOutput(Mission mission, StringBuilder stringBuilder)
        {
            foreach (var robot in mission.Robots)
            {
                stringBuilder.AppendLine($"{robot.Coordinates.X} {robot.Coordinates.Y} {robot.Orientation.GetKeyCode()} {robot.GetLostStatus()}");
            }

            return stringBuilder;
        }

        private static void HandleLostState(Map map, Robot robot)
        {
            robot.FlagAsLost();
            map.AddLostRobotVector(DirectionVector.Create(robot.Coordinates, robot.Orientation));
        }
        private static void HandleMoveState(Map map, Robot robot, Coordinates nextCoordinates)
        {
            map.AddExploredTile(nextCoordinates);
            robot.MoveToCoordinates(nextCoordinates);
        }
    }
}
