namespace Domain.Models.Extensions
{
    public static class RobotExtensions
    {
        public static void RotateLeft(this Robot robot)
        {
            robot.Orientation.RotateCounterclockwise();
        }

        public static void RotateRight(this Robot robot)
        {
            robot.Orientation.RotateClockwise();
        }

        public static Coordinates GetForwardCoordinates(this Robot robot)
        {
            var orientation = robot.Orientation;

            // When robot faces West or East it moves in axis X, as it would happen on axis Y with North and South orientation
            var yAxisTiles = orientation.Equals(OrientationType.North) || orientation.Equals(OrientationType.South) ? robot.Steps : 0;
            var xAxisTiles = orientation.Equals(OrientationType.West) || orientation.Equals(OrientationType.East) ? robot.Steps : 0;

            // When moving towards South or West, we are facing a negative vector from a (0,0) to (-1, 0), for example
            if (orientation.Equals(OrientationType.South))
            {
                yAxisTiles *= -1;
            }

            if (orientation.Equals(OrientationType.West))
            {
                xAxisTiles *= -1;
            }

            return robot.Coordinates + Coordinates.Create(xAxisTiles, yAxisTiles);
        }

        public static void FlagAsLost(this Robot robot)
        {
            robot.IsLost = true;
        }

        public static void MoveToCoordinates(this Robot robot, Coordinates coordinates)
        {
            robot.Coordinates = coordinates;
        }
    }
}
