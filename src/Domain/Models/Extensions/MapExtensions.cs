using System.Linq;

namespace Domain.Models.Extensions
{
    public static class MapExtensions
    {
        public static TileStatusType CheckTileStatus(this Map map, Robot robot, Coordinates nextCoordinates)
        {
            if (map.LostRobotVectors.Any(tile => tile.Equals(DirectionVector.Create(robot.Coordinates, robot.Orientation))))
            {
                return TileStatusType.Ignore;
            }
            else if (map.AreCoordinatesOutside(nextCoordinates))
            {
                return TileStatusType.Lost;
            }

            return TileStatusType.Move;
        }

        public static bool AreCoordinatesOutside(this Map map, Coordinates coordinates)
        {
            if (coordinates.X < map.BottomLeft.X || coordinates.X > map.TopRight.X) return true;
            if (coordinates.Y < map.BottomLeft.Y || coordinates.Y > map.TopRight.Y) return true;

            return false;
        }

        public static void AddLostRobotVector(this Map map, DirectionVector vector)
        {
            map.LostRobotVectors.Add(vector);
        }
        public static void AddExploredTile(this Map map, Coordinates coordinates)
        {
            if (!map.ExploredTiles.Contains(coordinates))
            {
                map.ExploredTiles.Add(coordinates);
            }
        }

        public static int GetNumberOfTiles(this Map map)
        {
            return (map.TopRight.X + 1) * (map.TopRight.Y + 1);
        }
    }
}
