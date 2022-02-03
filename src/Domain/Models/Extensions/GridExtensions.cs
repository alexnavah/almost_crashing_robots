using System.Linq;

namespace Domain.Models.Extensions
{
    public static class GridExtensions
    {
        public static TileStatusType CheckTileStatus(this Grid grid, Coordinates nextCoordinates)
        {
            if (grid.LostRobotVectors.Any(tile => tile.Equals(nextCoordinates)))
            {
                return TileStatusType.Ignore;
            }
            else if (!grid.AreCoordinatesOutside(nextCoordinates))
            {
                return TileStatusType.Lost;
            }

            return TileStatusType.Move;
        }

        public static bool AreCoordinatesOutside(this Grid grid, Coordinates coordinates)
        {
            if (coordinates.X < grid.BottomLeft.X || coordinates.X > grid.TopRight.X) return true;
            if (coordinates.Y < grid.BottomLeft.Y || coordinates.Y > grid.TopRight.Y) return true;

            return false;
        }

        public static void AddLostRobotVector(this Grid grid, DirectionVector vector)
        {
            grid.LostRobotVectors.Add(vector);
        }
        public static void AddSafetile(this Grid grid, Coordinates coordinates)
        {
            grid.SafeTiles.Add(coordinates);
        }
    }
}
