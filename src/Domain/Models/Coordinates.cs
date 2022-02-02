using System;

namespace Domain.Models
{
    public class Coordinates : IEquatable<Coordinates>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Coordinates Create(int x, int y)
        {
            return new Coordinates
            {
                X = x,
                Y = y
            };
        }

        public static Coordinates GetZeroZero()
        {
            return Create(0, 0);
        }

        public bool Equals(Coordinates other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
