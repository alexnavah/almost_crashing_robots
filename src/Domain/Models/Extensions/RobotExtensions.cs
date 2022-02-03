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
    }
}
