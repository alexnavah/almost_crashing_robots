using System.Collections.Generic;

namespace Domain.Models
{
    public class Map
    {
        private Map()
        {
            LostRobotVectors = new List<DirectionVector>();
            SafeTiles = new List<Coordinates>();
        }

        public Coordinates BottomLeft => Coordinates.ZeroZero;
        public Coordinates TopRight { get; set; }
        public List<DirectionVector> LostRobotVectors { get; set; }
        public List<Coordinates> SafeTiles { get; set; }

        public static Map Create(int x, int y)
        {
            return new Map
            {
                TopRight = Coordinates.Create(x, y)
            };
        }
    }
}
