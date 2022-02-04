using System;

namespace Domain.Models
{
    public class Robot : IEquatable<Robot>
    {
        private Robot()
        {
            Commands = string.Empty;
        }

        public Coordinates Coordinates { get; set; }
        public OrientationType Orientation { get; set; }
        public string Commands { get; set; }
        public bool IsLost { get; set; }

        public int Steps => 1;

        public static Robot Create(int coordinateX, int coordinateY, OrientationType orientation)
        {
            return new Robot
            {
                Coordinates = Coordinates.Create(coordinateX, coordinateY),
                Orientation = orientation
            };
        }

        public static Robot Create(int coordinateX, int coordinateY, OrientationType orientation, bool isLost)
        {
            var robot = Create(coordinateX, coordinateY, orientation);
            robot.IsLost = isLost;

            return robot;
        }
        public static Robot Create(int coordinateX, int coordinateY, OrientationType orientation, string commands)
        {
            var robot = Create(coordinateX, coordinateY, orientation);
            robot.Commands = commands;

            return robot;
        }

        public void SetOrientation(OrientationType orientation)
        {
            Orientation = orientation;
        }

        public void FlagAsLost()
        {
            IsLost = true;
        }

        public void MoveToCoordinates(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public bool Equals(Robot other)
        {
            return Coordinates.Equals(other.Coordinates)
                && Orientation.Equals(other.Orientation);
        }

        public override int GetHashCode()
        {
            return Coordinates.GetHashCode() ^ Orientation.GetHashCode();
        }
    }
}
