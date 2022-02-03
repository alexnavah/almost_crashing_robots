using System;

namespace Domain.Models
{
    public class Coordinates : IEquatable<Coordinates>
    {
        private static Coordinates Origin;
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

        public static Coordinates operator +(Coordinates a, Coordinates b) => Create(a.X + b.X, a.Y + b.Y);

        public static Coordinates ZeroZero => Origin ??= Create(0, 0);

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
