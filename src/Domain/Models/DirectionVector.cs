using System;

namespace Domain.Models
{
    public class DirectionVector : Coordinates, IEquatable<DirectionVector>
    {
        public OrientationType Orientation { get; set; }

        public static DirectionVector Create(Coordinates coordinates, OrientationType orientationType)
        {
            return new DirectionVector
            {
                Orientation = orientationType,
                X = coordinates.X,
                Y = coordinates.Y
            };
        }
        public bool Equals(DirectionVector other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Orientation.Equals(other.Orientation);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Orientation.GetHashCode();
        }
    }
}
